

namespace Repose_Record
{
    public class GuardSleepInformation
    {
        /// <summary>
        /// The total number of minutes asleep for this guard.
        /// </summary>
        public int TotalMinutesAsleep { get; set; }
        /// <summary>
        /// The minute that most commonly has this guard sleeping.
        /// </summary>
        public int MinuteMostCommonlyAsleep { get; set; }
        /// <summary>
        /// The amount of times a guard was sleeping in the most commonly slept minute
        /// </summary>
        public int TimesCommonMinuteSleptIn { get; set; }
    }
}
