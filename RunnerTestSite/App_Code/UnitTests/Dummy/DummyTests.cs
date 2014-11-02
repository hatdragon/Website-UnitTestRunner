using System;
using WebsiteUnitTestRunner.Testing.UnitTesting;

namespace UnitTests.Dummy
{


    /// <summary>
    /// Test fixture for Dummy class unit tests
    /// </summary>
    [TestFixture]
    public class DummyTests : UnitTestBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyTests"/> class.
        /// </summary>
        public DummyTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [Test(Name = "Failure", Ignore = false, Options = TestOptions.Standard)]
        public void DummyTest_Fail()
        {
            Assert.Fail();
        }

        [Test]
        public void TestHelloWorld()
        {
            String expected = "hello world";
            String actual = "hello WORLD".ToLowerInvariant();

            AddLogData("TestHelloWorld", String.Format("Expected: {0} – Actual: {1}", expected, actual));
            Assert.AreEqual(expected, actual);
        }

    }
}