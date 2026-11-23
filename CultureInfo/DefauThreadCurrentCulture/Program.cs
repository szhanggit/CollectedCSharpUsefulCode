using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DefauThreadCurrentCulture
{
    class Program
    {
        static void Main(string[] args)
        {
            double val = 1235.56;

            Console.WriteLine($"Current culture: {CultureInfo.CurrentCulture.Name}");
            Console.WriteLine(val);

            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");

            Console.WriteLine($"Current culture: {CultureInfo.CurrentCulture.Name}");
            Console.WriteLine(val);

            Console.ReadLine();
        }
    }
}
