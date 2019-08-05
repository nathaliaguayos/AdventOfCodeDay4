

namespace Repose_Record
{
    /// <summary>
    /// Author: Nathali Aguayo
    /// </summary>
    public class GuardSleepInformation
    {
        /// <summary>
        /// This is the total minutes that the guard sleeps 
        /// </summary>
        public int TotalMinutesAsleep { get; set; }
        /// <summary>
        /// This stored the minute in which the guard is commonly sleeping 
        /// </summary>
        public int MinuteMostCommonlyAsleep { get; set; }
        /// <summary>
        /// Count the times in which the guard is sleeping in the most commonly slept minute
        /// </summary>
        public int TimesCommonMinuteSleptIn { get; set; }
    }
}
