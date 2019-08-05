using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repose_Record;

namespace Repose_Record_Test
{
    /// <summary>
    /// Author: Nathali Aguayo
    /// </summary>
    [TestClass]
    public class FindTheMostSleepyheadGuard_Test
    {
        private static int resultStrategy1 = 84834;
        private static int resultStrategy1SampleTest = 240;
        /// <summary>
        /// Description: This is the test of the sample for Strategy 1
        /// </summary>
        [TestMethod]
        public void ReposeRecordSampleTest_S1()
        {
            String[] guardsRecords = Properties.Resources.TestInput.Split('\n');
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();
            var result = guardRecordsProcessor.FindTheMostSleepyheadGuard(guardsRecords);
            Assert.AreEqual(resultStrategy1SampleTest, result);
        }

        /// <summary>
        /// Description: This is the test for Strategy 1
        /// </summary>
        [TestMethod]
        public void ReposeRecordTest_S1()
        {
            String[] guardsRecords = Properties.Resources.InputFile.Split('\n');
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();
            var result = guardRecordsProcessor.FindTheMostSleepyheadGuard(guardsRecords);
            Assert.AreEqual(resultStrategy1, result);
        }
        /// <summary>
        /// Description: This test method is to test the response is different to null
        /// </summary>
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
