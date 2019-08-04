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
        public List<GuardLogger> guardLogger { get; set; } = new List<GuardLogger>();

    }
}
