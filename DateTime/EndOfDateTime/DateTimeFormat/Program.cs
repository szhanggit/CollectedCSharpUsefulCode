using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            string dtstr = dt.ToString("yyyyMMddHHmmss");
            string dddd = DateTime.Now.ToString("dddd");
            int d = DateTime.Now.Day;
            bool flag = DateTime.Now.DayOfWeek == DayOfWeek.Wednesday;

            int i = Helper.GetLocalDate(DateTime.Now);
        }
    }
}
