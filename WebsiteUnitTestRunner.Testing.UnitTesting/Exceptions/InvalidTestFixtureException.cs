using System;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    [Serializable]
    class InvalidTestFixtureException : Exception
    {

        public InvalidTestFixtureException()
            : base()
        {
        }

        public InvalidTestFixtureException(string message)
            : base(message)
        {
        }

        public InvalidTestFixtureException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}