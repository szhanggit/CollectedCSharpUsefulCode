using System;
using System.Globalization;

namespace CultureInfoDatetimeFormats
{
    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;

            var skSk = new CultureInfo("sk-SK");
            CultureInfo.DefaultThreadCurrentCulture = skSk;

            Console.WriteLine(skSk.DateTimeFormat.FullDateTimePattern);
            Console.WriteLine(now.ToString(skSk.DateTimeFormat.FullDateTimePattern));

            Console.WriteLine();

            Console.WriteLine(skSk.DateTimeFormat.LongDatePattern);
            Console.WriteLine(now.ToString(skSk.DateTimeFormat.LongDatePattern));

            Console.WriteLine();

            Console.WriteLine(skSk.DateTimeFormat.ShortTimePattern);
            Console.WriteLine(now.ToString(skSk.DateTimeFormat.ShortTimePattern));

            var cultureInfo = new CultureInfo("sk-SK");
            Console.WriteLine(now.ToString($"{cultureInfo.DateTimeFormat.ShortDatePattern} {cultureInfo.DateTimeFormat.LongTimePattern}"));

            string StartDate = now.ToDateString((new CultureInfo("sk-SK")).DateTimeFormat.ShortDatePattern.ToLower());

            Console.ReadLine();
        }
    }
}
