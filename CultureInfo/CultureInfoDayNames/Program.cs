using System;
using System.Globalization;

namespace CultureInfoDayNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var enUs = new CultureInfo("en-US");

            foreach (var dayName in enUs.DateTimeFormat.DayNames)
            {
                Console.WriteLine(dayName);
            }

            Console.WriteLine("***************************");

            var skSk = new CultureInfo("sk-SK");

            foreach (var dayName in skSk.DateTimeFormat.DayNames)
            {
                Console.WriteLine(dayName);
            }

            Console.ReadLine();
        }
    }
}
