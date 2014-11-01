using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    [Serializable]
    [CollectionDataContract(Name = "ExtendedLogData", ItemName = "LogItem", Namespace = "")]
    public class TestExtendedLogData : Dictionary<string, TestExtendedLogDataEntries>
    {
        public TestExtendedLogData()
        {
        }

        protected TestExtendedLogData(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    [Serializable]
    [CollectionDataContract(Name = "Entries", ItemName = "Entry", Namespace = "")]
    public class TestExtendedLogDataEntries : List<string> { }
}
