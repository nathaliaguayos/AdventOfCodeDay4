using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repose_Record;

namespace Repose_Record_Test.Strategy2
{
    /// <summary>
    /// Summary description for FindTheMostSleepyheadGuardInTheSameMinute_Test
    /// </summary>
    [TestClass]
    public class FindTheMostSleepyheadGuardInTheSameMinute_Test
    {
        private static int resultStrategy1 = 53427;
        private static int resultStrategy1SampleTest = 4455;
        [TestMethod]
        public void ReposeRecordSampleTest_S2()
        {
            String[] guardsRecords = Properties.Resources.TestInput.Split('\n');
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();
            var result = guardRecordsProcessor.FindTheMostSleepyheadGuardInTheSameMinute(guardsRecords);
            Assert.AreEqual(resultStrategy1SampleTest,result);
        }
        [TestMethod]
        public void ReposeRecordExampleTest_S1_IsNotNull()
        {
            String[] guardsRecords = Properties.Resources.TestInput.Split('\n');
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();
            var result = guardRecordsProcessor.FindTheMostSleepyheadGuardInTheSameMinute(guardsRecords);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ReposeRecordTest_S2()
        {
            String[] guardsRecords = Properties.Resources.InputFile.Split('\n');
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();
            var result = guardRecordsProcessor.FindTheMostSleepyheadGuardInTheSameMinute(guardsRecords);
            Assert.AreEqual(resultStrategy1, result);
        }
    }
}
