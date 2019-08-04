using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repose_Record
{
    class GuardRecordsMonitoring
    {
        public int guardId { get; set; }
        public List<GuardLogger> GuardLogger { get; set; } = new List<GuardLogger>();

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
        /// Keyed on the minute,
        /// valued on the number of times minute is slept in by a specific guard
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
