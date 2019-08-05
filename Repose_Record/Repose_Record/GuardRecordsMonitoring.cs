using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repose_Record
{
    /// <summary>
    /// Author: Nathali Aguayo
    /// </summary>
    class GuardRecordsMonitoring
    {
        public int guardId { get; set; }
        public List<GuardLogger> GuardLogger { get; set; } = new List<GuardLogger>();

        /// <summary>
        /// Description: This method generates and returns an object that contains all the sleep habits of the guard.
        /// </summary>
        /// <returns></returns>
        public GuardSleepInformation GetGuardSleepInformation()
        {
            DateTime takeNap =new DateTime();
            DateTime finishNap=new DateTime();

            var minutesInHourDictionary = FillMinutesInHourDictionary();

            foreach (var currentRecord in GuardLogger)
            {
                switch (currentRecord.guardStatus)
                {
                    case GuardStatus.FallsAsleep:
                        takeNap = currentRecord.recordTime;
                        break;
                    case GuardStatus.AwakesUp:
                        finishNap = currentRecord.recordTime;
                        GetTimeSpentSleeping(takeNap, finishNap, ref minutesInHourDictionary);
                        break;
                }
            }
            var maxTimesMinuteSlept = minutesInHourDictionary.Values.Max(); 
            var mostAsleepMinute = maxTimesMinuteSlept;

            return new GuardSleepInformation()
            {
                TotalMinutesAsleep = minutesInHourDictionary.Values.Sum(),
                MinuteMostCommonlyAsleep = minutesInHourDictionary.First(minute => minute.Value==mostAsleepMinute).Key,
                TimesCommonMinuteSleptIn = maxTimesMinuteSlept
            };
        }

        /// <summary>
        /// Description: This method initialized the dictionary with the 60 minutes that an hour contains. 
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, int> FillMinutesInHourDictionary()
        {
            var minutesInHourSleepTracking = new Dictionary<int, int>();

            // one index for each minute in an hour
            for (var i = 0; i < 60; i++)
            {
                minutesInHourSleepTracking.Add(i, 0);
            }

            return minutesInHourSleepTracking;
        }
        /// <summary>
        /// Description: This method is in charge of log the minutes spent in the nap. 
        /// </summary>
        /// <param name="takeNap"></param>
        /// <param name="finishNap"></param>
        /// <param name="minutesInHourDictionary"></param>
        private void GetTimeSpentSleeping(DateTime takeNap, DateTime finishNap, ref Dictionary<int, int> minutesInHourDictionary)
        {
            int startMinute = takeNap.Minute;
            int endMinute = finishNap.Minute;

            for (var i = startMinute; i < endMinute; i++)
            {
                minutesInHourDictionary[i]++;
            }
        }
    }
}
