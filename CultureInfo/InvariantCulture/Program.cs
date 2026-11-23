using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvariantCulture
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            DateTime[] dates = {
                new DateTime(2019, 10, 9),
                new DateTime(2020, 1, 2)
            };

            //using var sw = new StreamWriter(@"C:\Users\Jano\Documents\tmp\dates.dat");
            //sw.Write(String.Format(CultureInfo.InvariantCulture,
            //    "{0:d}|{1:d}", dates[0], dates[1]));

            Console.ReadLine();
        }
    }
}
