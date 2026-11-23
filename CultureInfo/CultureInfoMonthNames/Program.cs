using System;
using System.Globalization;

namespace CultureInfoMonthNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var huHu = new CultureInfo("hu-HU");
            var name = huHu.NativeName;

            Console.WriteLine($"{name}: Hónap nevek");

            foreach (var monthName in huHu.DateTimeFormat.MonthNames)
            {
                Console.WriteLine(monthName);
            }

            Console.WriteLine("**********************");

            foreach (var abbMonthName in huHu.DateTimeFormat.AbbreviatedMonthNames)
            {
                Console.WriteLine(abbMonthName);
            }

            Console.ReadLine();
        }
    }
}
