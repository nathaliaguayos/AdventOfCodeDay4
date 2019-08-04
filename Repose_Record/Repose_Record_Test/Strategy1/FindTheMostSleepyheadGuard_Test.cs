using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repose_Record;

namespace Repose_Record_Test
{
    [TestClass]
    public class FindTheMostSleepyheadGuard_Test
    {
        private static int resultStrategy1 = 84834;
        private static int resultStrategy1SampleTest = 240;
        [TestMethod]
        public void ReposeRecordSampleTest_S1()
        {
            String[] guardsRecords = Properties.Resources.TestInput.Split('\n');
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();
            var result = guardRecordsProcessor.FindTheMostSleepyheadGuard(guardsRecords);
            Assert.AreEqual(resultStrategy1SampleTest, result);
        }
        [TestMethod]
        public void ReposeRecordTest_S1()
        {
            String[] guardsRecords = Properties.Resources.InputFile.Split('\n');
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();
            var result = guardRecordsProcessor.FindTheMostSleepyheadGuard(guardsRecords);
            Assert.AreEqual(resultStrategy1, result);
        }
        [TestMethod]
        public void ReposeRecordExampleTest_S1_IsNotNull()
        {
            String[] guardsRecords = Properties.Resources.TestInput.Split('\n');
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();
            var result = guardRecordsProcessor.FindTheMostSleepyheadGuard(guardsRecords);
            Assert.IsNotNull(result);
        }
    }
}
