using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repose_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] guardsRecords = Properties.Resources.Input.Split('\n');
            //FindTheMostSleepyheadGuard findTheMostSleepyheadGuard = new FindTheMostSleepyheadGuard();
            GuardRecordsProcessor guardRecordsProcessor = new GuardRecordsProcessor();
            guardRecordsProcessor.FindTheMostSleepyheadGuard(guardsRecords);
        }
    }
}
