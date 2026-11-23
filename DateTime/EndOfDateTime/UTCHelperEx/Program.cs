using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTCHelperEx
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentUTCDate = UTCHelper.ToUTCTime(DateTime.Now, "08:00");
            DateTime localDateTime = UTCHelper.ToLocalTime(DateTime.UtcNow, "08:00");
            int time = UTCHelper.GetUtcTimestamp(DateTime.Now);
        }
    }
}
