#Website-UnitTestRunner


##Abstract
This document outlines a baseline for an ASP.NET based unit test framework.  It will define the basic outline, workflow, and underlining technology used in this implementation. This is primarily used to test non-web application type ASP.NET web sites. 

###Getting Started
This section will provide you with the very basic information that is needed to get started with this unit test framework in the context of your web solutions.  This will provide a step by step guide to installation of needed components and their usage. 

###Installation and Setup
1.	Add references to WebsiteUnitTestRunner.Testing.UnitTesting
2.	In the App_Code folder of the web solution, create a subdirectory called UnitTests, if it does not exist.  Please refer to the recommended folder structure for more info.
3.	In your web.config, in the system.webServer section, ensure you have at minimum:
```
<modules>
      <remove name="Session" /> 
      <remove name="UrlRoutingModule-4.0"/>
      <add name="Session" type="System.Web.SessionState.SessionStateModule"/>
      <add name="UrlRoutingModule-4.0" type="System.Web.Routing.UrlRoutingModule" preCondition="" />
</modules>
```

This will allow url routing to be enabled, as well as allowing the handler access to session state.  Any other IIS Module that is required will similarly need to be removed and re-added with a blank precondition attribute.

For more information on this need, see: http://www.heartysoft.com/aspnet-routing-iis7-remember-modules

4.	In the global.asax  you will need the following changes:

a.	if not present, add the following method, or ensure the existing method contains the 
```
private static void RegisterRoutes(RouteCollection routes)
{
   routes.MapUnitTestsHandler();
}
```

b.	In your `Application_Start(...)` method in the global.cs append the following line, if not already present:
    	`RegisterRoutes(RouteTable.Routes);`


5.	Create a class for your unit tests and ensure that the page is inheriting UnitTestBase.  This class MUST reside in the namespace UnitTests.

###Creating Your First Test
If you have any familiarity with test suites, such as NUnit or MSTest, much of this framework will seem familiar to you.  Most of the baseline test attributes have been modeled in such a way that a simple transition could be made from other suites.

Any test that is created must be public, contain no input parameters, and must not have a return.  A basic example is provided below. 

```
namespace UnitTests {
  [TestFixture]
  public class MyTestClass {
    [Test]
    public void TestHelloWorld() {
      String expected = “hello world”;
      String actual = “hello WORLD”.ToLowerInvariant();	
  
      AddLogData(String.Format(“Expected: {0} – Actual: {1}”, expected, actual));
      Assert.AreEqual(expected, actual);
    }
  }
}
```

At this point, you are set to start writing unit tests.  By default, your tests will execute and will return xml formatted data with your results.  If this default is not the desired behavior, you can request data from the handler in several other formats, as outlined in ‘Viewing Test Results.’

###Technical Specifications
This Unit Test Suite is very similar in implementation as many other libraries on the market at the moment, though very scaled back in its depth. The main difference is that this suite can be easily used to perform integration tests in our web applications, a feature sorely overlooked by most test frameworks today.  Like other testing frameworks, It uses attributes to flag a method as a test.  It requires that the test method be public, have no input parameters, and no return value.  In order to facilitate adoption of the technology, it was decided to keep it as similar as possible to existing frameworks.  

###Viewing Test Results
The current implementation of the UnitTestHandler will allow data to be returned to the caller in several formats.  The following is a list of all of the available output types and the required querystring information needed to access them.
In order to access your tests you will just have to point your browser to `http://<siteaddress>/_UnitTests/<Test_Set>/<your_unit_test_class>`

In this url string, you must keep in mind that the unit test names and paths are case sensitive and will need to match the case used on your test assembly.

If the default XML format provided is not the output you want, then the following table will further explain your available output types and how to get them.

Output Type	Required querystring argument(s):

**HTML**	`http://<siteaddress>/_UnitTests/<Test_Set>/<your_unit_test_class>?responsetype=html`

**JSON**	`http://<siteaddress>/_UnitTests/<Test_Set>/<your_unit_test_class>?responsetype=json`

**XML**	`http://<siteaddress>/_UnitTests/<Test_Set>/<your_unit_test_class>?responsetype=xml`
This is default return type, so no querystring is technically required

**Transformed XML**	`http://<siteaddress>/_UnitTests/<Test_Set>/<your_unit_test_class>?Responsetype=xslt&Xsltpath=<location from app root to desired transform>`

For testing one (or more) methods instead of all the methods in the test class, you could pass one more query string `"&testmethod=method1,methods2"`
Example:  `http://<siteaddress>/_UnitTests/<Test_Set>/<your_unit_test_class>?responsetype=html&testmethod=method1,method2` (The methods can be separated by "," or "|" delimiters)

There are examples of XSL Transforms available in the appendix to apply to the xml data returned by the test suite. 

###Base Classes
For this solution, there is a single base class in use, `UnitTestBase`. (See Class Diagrams)
The majority of the processing for the unit test framework is handled in the UnitTestHandler. This handler passes the bulk of its processing off to the TestRunner class.  Using reflection, this class pulls a list of the Tests via their attributes, as well as the various setup and teardown functions.

If a setup or teardown fixture is present, a reference to it is set and executed at the start and end of our test loop.  In a similar manner, if a test setup or teardown is present, a reference to the setup and teardown is set and they are executed at the beginning or end of each test, as appropriate.

Based on the test attributes, we can also set a test to be ignored or label it as destructive.  This will allow us to skip a given test altogether, or ensure that a destructive test isn’t unintentionally run.  There is a property exposed on [TestFixture] attribute, AllowDestructiveTests, which will allow a user to setup the suite to allow running of destructive tests.  If this property is set to true, then all tests in the suite that are NOT marked as Ignore will be run.

For each test in the suite, a success or failure will be added to the TestResults collection to be rendered at completion of running tests.

A user can also use this base class’s method to log additional data related to the tests, which will also be rendered to screen once all tests are complete.

###Interfaces
There is one interface declared. This is utilized by the base class to ensure the proper implementation for data related to the tests.   

###Unit Test Attributes
The valid attributes used for this test suite are as follows:

**[TestFixture]**	Required on Test Class – This attribute tags a class as testable.
AllowDestructiveTests can be set to Allow the execution of potentially destructive tests.

**[TestFixtureSetup]**  	Defines method to run once prior to all tests. Used to initialize suite of tests that may need shared resource(s).

**[TestFixtureTeardown]**	Defines method to run once after all tests are complete. Used to initialize suite of tests that may need to de-allocate some shared resource(s).
 
**[TestSetup]**	Run before every test to ensure a function or set of functions are performed just before each test method is called

**[TestTeardown]**	Run before every test to ensure a function or set of functions are performed just after each test method is called

**[Test]**		Required on Test - Defines test to run, can specify the following parameters: 

```
- Ignore (bool)
- Options (bitmasked enum)
    Valid options are:
      TestOptions.Standard
      TestOptions.Destructive
    or values in combination

- Name (string)
```

**[TestExpectedException]**	Specifies that the execution of a test will throw an exception  
ExceptionType (Type)

The additional parameters on the Test attribute will allow us to set a test to be ignored or label it as destructive.

###Unit Test Assertions
A static helper class called Assert is available to manage the Assertions for the tests.  While not extremely extensive at the moment, this could be fleshed out to handle more than just basic assert types.   Currently this class will manage AreEqual/AreNotEqual, Contains, IsNull/IsNotNull, IsEmpty/IsNotEmpty, InInstanceOfType/IsNotInstanceOfType, and  IsTrue/IsFalse conditions.  It also can assert a general Fail in order for developers to handle cases in unit tests that are not as simple as one of these basic assert types can handle.

###Custom Exceptions
If an assertion fails, we throw a custom error, AssertionFailedException, which is caught by the base class and handled as a failed test.

###Folder Structure
All unit test pages should be created in the UnitTests folder of the site’s app_code folder.  A typical folder structure for unit tests might look like this:

```
\App_Code\
  UnitTests\
	   \<test set folder name>
		TestType1.cs
		TestType2.cs
```

The test set folder name should match the folder of the class you are unit testing in the App_Code root.  All of the unit tests MUST live within the UnitTests namespace.

###Tests
The tests themselves are created a class file in the app_code location described above.  For what we’re doing, this is the recommended layout for said unit test pages so far.  The code behind for the ASPX will need to inherit from `UnitTestBase`.  This base class will allow the test runner to aggregate and return XML content representing the data from the TestResults and ExtendedTestData collections in order to display the result data in a digestible format.  

As mentioned when reviewing the Attributes section, a test can be flagged to Ignore and this will cause a test to not be run. The syntax for ignoring a test is `[Test(Ignore=True)]`.   You can also tag a test as destructive by setting `Options = TestOptions.Destructive`.  

What this means is that the actions contained in a given test may cause additional test runs to fail, as the action in the test may delete data or change it in such a way that the original tests may fail when trying to evaluate the test conditions. This type of test is non-standard and should only be utilized in local development environments.

The unit tests in this page will be set up using the attributes defined previously and will follow the format in the example below.  

```
namespace UnitTests {
  [TestFixture]
  public class MyTestClass {
    [Test]
    public void TestHelloWorld() {
      String expected = “hello world”;
      String actual = “hello WORLD”.ToLowerInvariant();	
  
      AddLogData(String.Format(“Expected: {0} – Actual: {1}”, expected, actual));
      Assert.AreEqual(expected, actual);
    }
  }
}
```

