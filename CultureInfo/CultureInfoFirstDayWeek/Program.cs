using System;
using System.Globalization;

namespace CultureInfoFirstDayWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            var enUs = new CultureInfo("en-US");

            var firstDay = enUs.DateTimeFormat.FirstDayOfWeek.ToString();
            var name = enUs.DisplayName;
            Console.WriteLine($"First day of the week in {name}: {firstDay}");

            var skSk = new CultureInfo("sk-Sk");

            var name2 = skSk.DisplayName;
            var firstDay2 = skSk.DateTimeFormat.FirstDayOfWeek.ToString();
            Console.WriteLine($"First day of the week in {name2}:: {firstDay2}");

            var faIr = new CultureInfo("fa-IR");

            var name3 = faIr.DisplayName;
            var firstDay3 = faIr.DateTimeFormat.FirstDayOfWeek.ToString();
            Console.WriteLine($"First day of the week in {name3}:: {firstDay3}");

            Console.ReadLine();
        }
    }
}
