using System;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    public interface IUnitTestCollection
    {
        Type CollectionAttribute { get; }
    }
}