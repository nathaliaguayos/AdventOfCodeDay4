using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repose_Record;

namespace Repose_Record_Test.Strategy2
{
    /// <summary>
    /// Author: Nathali Aguayo
    /// </summary>
    [TestClass]
    public class FindTheMostSleepyheadGuardInTheSameMinute_Test
    {
        private static int resultStrategy1 = 53427;
        private static int resultStrategy1SampleTest = 4455;

        /// <summary>
        /// Description: This is the test of the sample for Strategy 2
        /// </summary>
        [TestMethod]
        public void ReposeRecordSampleTest_S2()
        {
            String[] guardsRecords = Properties.Resources.TestInput.Split('\n');
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();
            var result = guardRecordsProcessor.FindTheMostSleepyheadGuardInTheSameMinute(guardsRecords);
            Assert.AreEqual(resultStrategy1SampleTest,result);
        }
        /// <summary>
        /// Description: This test method is to test the response is different to null
        /// </summary>
        [TestMethod]
        public void ReposeRecordExampleTest_S2_IsNotNull()
        {
            String[] guardsRecords = Properties.Resources.TestInput.Split('\n');
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();
            var result = guardRecordsProcessor.FindTheMostSleepyheadGuardInTheSameMinute(guardsRecords);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Description: This is the test for Strategy 2
        /// </summary>
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
