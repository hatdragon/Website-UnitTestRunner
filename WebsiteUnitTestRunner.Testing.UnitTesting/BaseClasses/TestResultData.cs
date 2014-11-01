﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    [DataContract(IsReference = false, Name = "TestResultData", Namespace = "")]
    public class TestResultData : ITestResults
    {
        private TestExtendedLogData _extLogData;
        private List<TestResultBase> _testResults;
        private TestResultSummary _summary;

        [DataMember]
        public List<TestResultBase> TestResults
        {
            get
            {
                if (_testResults == null)
                {
                    _testResults = new List<TestResultBase>();
                }
                return _testResults;
            }
            set { _testResults = value; }
        }

        [DataMember]
        public TestExtendedLogData ExtendedLogData
        {
            get
            {
                if (_extLogData == null)
                {
                    _extLogData = new TestExtendedLogData();
                }
                return _extLogData;
            }
        }

        [DataMember]
        public int ProcessId { get; set; }

        [DataMember]
        public string AssemblyFileVersion { get; set; }

        [DataMember]
        public string ExecutingServerName { get; set; }

        [DataMember]
        public TestResultSummary Summary
        {
            get
            {
                if (_summary == null)
                {
                    _summary = new TestResultSummary();
                }
                return _summary;
            }
            set { _summary = value; }
        }

    }
}