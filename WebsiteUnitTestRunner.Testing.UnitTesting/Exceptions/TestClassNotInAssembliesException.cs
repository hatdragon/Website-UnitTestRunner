using System;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    [Serializable]
    public class TestClassNotInAssembliesException : Exception
    {

        public TestClassNotInAssembliesException()
            : base()
        {
        }

        public TestClassNotInAssembliesException(string message)
            : base(message)
        {
        }

        public TestClassNotInAssembliesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}