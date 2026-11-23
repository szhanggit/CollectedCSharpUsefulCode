using System;
using System.Globalization;

namespace CultureInfoCurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double val = 12_156_320.54;

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("sk-SK");
            Console.WriteLine($"{val:c}");

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ff-NG");
            Console.WriteLine($"{val:c}");

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fil-PH");
            Console.WriteLine($"{val:c}");

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("zh-CN");
            Console.WriteLine($"{val:c}");

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            Console.WriteLine($"{val:c}");

            Console.ReadLine();
        }
    }
}
