using System;

namespace Repose_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] guardsRecords = Properties.Resources.Input.Split('\n');
            //String[] guardsRecords = Properties.Resources.TestPart1.Split('\n');
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();

            Console.WriteLine("Part 1\n"+guardRecordsProcessor.FindTheMostSleepyheadGuard(guardsRecords));

            Console.WriteLine("\nPart 2\n" + guardRecordsProcessor.FindTheMostSleepyheadGuardInTheSameMinute(guardsRecords));
            Console.Read();
        }
    }
}
