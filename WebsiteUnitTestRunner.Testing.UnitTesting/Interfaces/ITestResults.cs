using System.Collections.Generic;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    public interface ITestResults
    {
        List<TestResultBase> TestResults { get; set; }
        TestExtendedLogData ExtendedLogData { get; }
    }
}