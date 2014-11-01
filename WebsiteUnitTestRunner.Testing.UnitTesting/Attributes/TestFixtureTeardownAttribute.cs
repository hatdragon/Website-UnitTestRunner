using System;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class TestFixtureTeardownAttribute : Attribute
    {
        public TestFixtureTeardownAttribute()
        {
        }
    }
}
