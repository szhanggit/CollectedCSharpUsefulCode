using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndOfDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2021, 4, 7, 21, 38, 00);
            DateTime dat = dt.Date.AddDays(1);
            DateTime end = dt.Date.AddDays(1).AddSeconds(-1);

            string dateTime = "2021-05-03";
            DateTime dtt = dateTime.ParseToEndDateTime(DateTime.Now);
        }
    }
}
