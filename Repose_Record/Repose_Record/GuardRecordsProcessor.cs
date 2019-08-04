using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repose_Record
{
    public class GuardRecordsProcessor
    {
        //Strategy 1
        public int FindTheMostSleepyheadGuard(string[] guardsRecords)
        {
            //var guardRecordsOrdered= OrderRecordsByDate(guardsRecords);
            //var getRecordsPerGuard = GetRecordsPerGuard(guardRecordsOrdered);
            //var guardSleepDetails = new Dictionary<int, GuardSleepInformation>();

            //foreach (var currentRecord in getRecordsPerGuard)
            //{
            //    guardSleepDetails.Add(currentRecord.guardId,currentRecord.GetGuardSleepInformation());
            //}

            var guardSleepDetails = new Dictionary<int, GuardSleepInformation>();
            guardSleepDetails = GetGuardSleepDetails(guardsRecords);
            var maxTimeNap = guardSleepDetails.Values.Max(minute => minute.TotalMinutesAsleep);
            var mostLazyGuard = guardSleepDetails.First(minute => minute.Value.TotalMinutesAsleep == maxTimeNap);

            return mostLazyGuard.Key * mostLazyGuard.Value.MinuteMostCommonlyAsleep;
        }
        
        //Strategy 2
        public int FindTheMostSleepyheadGuardInTheSameMinute(string[] guardsRecords)
        {
            var guardSleepDetails = new Dictionary<int, GuardSleepInformation>();
            guardSleepDetails = GetGuardSleepDetails(guardsRecords);

            var timesCommonMinuteSleptIn = guardSleepDetails.Max(minute => minute.Value.TimesCommonMinuteSleptIn);
            var SleepyheadGuard =
                guardSleepDetails.First(minute => minute.Value.TimesCommonMinuteSleptIn == timesCommonMinuteSleptIn);
            var maxMinuteOfNap = SleepyheadGuard.Value.MinuteMostCommonlyAsleep;

            return SleepyheadGuard.Key * maxMinuteOfNap;
        }

        protected Dictionary<int, GuardSleepInformation> GetGuardSleepDetails(string[] guardsRecords)
        {
            var guardRecordsOrdered = OrderRecordsByDate(guardsRecords);
            var getRecordsPerGuard = GetRecordsPerGuard(guardRecordsOrdered);
            var guardSleepDetails = new Dictionary<int, GuardSleepInformation>();

            foreach (var currentRecord in getRecordsPerGuard)
            {
                guardSleepDetails.Add(currentRecord.guardId, currentRecord.GetGuardSleepInformation());
            }

            return guardSleepDetails;
        }
        private IDictionary<DateTime, string> OrderRecordsByDate(string[] guardsRecords)
        {
            var guardsRecordsOrderedDictionary = new Dictionary<DateTime, string>();

            
            var regex = new Regex(@"\[(?<dateTime>.*)(?=\])(?:.).<?(?<guardsRecords>.*)");

            foreach (var entry in guardsRecords)
            {
                var matches = regex.Match(entry);

                guardsRecordsOrderedDictionary.Add
                (
                    DateTime.Parse(matches.Groups["dateTime"].Value),
                    matches.Groups["guardsRecords"].Value
                );
            }
            return guardsRecordsOrderedDictionary.OrderBy(date => date.Key).
                ToDictionary(logRecord => logRecord.Key, logRecord => logRecord.Value);
        }

        private List<GuardRecordsMonitoring> GetRecordsPerGuard(IDictionary<DateTime, string> guardRecordsOrdered)
        {
            List<GuardRecordsMonitoring> guardRecordsMonitoringList = new List<GuardRecordsMonitoring>();
            var guardIdRegex = new Regex(@"(?<guardId>\d+)");

            //GuardRecordsMonitoring currentGuard = null;
            GuardRecordsMonitoring currentGuard = null;
            foreach (var currentRecord in guardRecordsOrdered)
            {
                if (currentRecord.Value.Contains("#"))
                {
                    var match = guardIdRegex.Match(currentRecord.Value);
                    var guardID = int.Parse(match.Groups["guardId"].Value);

                    //if the guard already exist in the list, then get its reference
                    if(guardRecordsMonitoringList.Any(id=>id.guardId==guardID))
                    {
                        currentGuard = guardRecordsMonitoringList.First(record => record.guardId == guardID);
                    }

                    //otherwise means it's a new guard in the list
                    else
                    {
                        currentGuard = new GuardRecordsMonitoring()
                        {
                            guardId = guardID
                        };
                        guardRecordsMonitoringList.Add(currentGuard);
                    }

                    //save the status
                    currentGuard.GuardLogger.Add
                    (
                        new GuardLogger()
                        {
                            recordTime = currentRecord.Key,
                            guardStatus = GuardStatus.Begins_Shift
                        }
                    );
                    continue;
                }
                //when a guard falls asleep
                if (currentRecord.Value.Contains("falls"))
                {
                    currentGuard.GuardLogger.Add
                    (
                        new GuardLogger()
                        {
                            recordTime = currentRecord.Key,
                            guardStatus = GuardStatus.FallsAsleep
                        }
                    );
                    continue;
                }
                //when a guard wakes up
                if (currentRecord.Value.Contains("wakes"))
                {
                    currentGuard.GuardLogger.Add
                    (
                        new GuardLogger()
                        {
                            recordTime = currentRecord.Key,
                            guardStatus = GuardStatus.AwakesUp
                        }
                    );
                    continue;
                }
            }
            return guardRecordsMonitoringList;
        }


    }


    struct GuardInformation
    {
        public int guardId { get; set; }
        public List<GuardLogger> guardLogger { get; set; }

    }
    public struct GuardLogger
    {
        public GuardStatus guardStatus { get; set; }
        public DateTime recordTime { get; set; }
    }
    public enum GuardStatus
    {
        Begins_Shift,
        AwakesUp,
        FallsAsleep
    }
}
