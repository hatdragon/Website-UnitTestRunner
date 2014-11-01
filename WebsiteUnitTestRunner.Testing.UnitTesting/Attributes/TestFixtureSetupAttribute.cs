using System;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class TestFixtureSetupAttribute : Attribute
    {
        public TestFixtureSetupAttribute() { }

    }
}
