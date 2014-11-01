using System;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    [Serializable]
    public class InvalidTestClassException : Exception
    {

        public InvalidTestClassException()
            : base()
        {
        }

        public InvalidTestClassException(string message)
            : base(message)
        {
        }

        public InvalidTestClassException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}