using System;
using System.Globalization;

namespace CultureInfoFirstWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            var enUs = new CultureInfo("en-US");

            var weekRule = enUs.DateTimeFormat.CalendarWeekRule.ToString();
            Console.WriteLine($"First calendar week starts with: {weekRule}");

            var skSk = new CultureInfo("sk-Sk");

            var weekRule2 = skSk.DateTimeFormat.CalendarWeekRule.ToString();
            Console.WriteLine($"First calendar week starts with: {weekRule2}");

            Console.ReadLine();
        }
    }
}
