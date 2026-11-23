using System;
using System.Globalization;

namespace CultureInfoDecimalSeparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double val = 1278.112;

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("sk-SK");
            Console.WriteLine($"{val}");

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            Console.WriteLine($"{val}");

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fa-IR");
            Console.WriteLine($"{val}");

            Console.ReadLine();
        }
    }
}
