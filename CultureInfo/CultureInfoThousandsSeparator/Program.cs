using System;
using System.Globalization;
using System.Threading;

namespace CultureInfoThousandsSeparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int val = 12_156_320;

            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("sk-SK");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("sk-SK");
            Console.WriteLine($"{val:N}");

            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            //Console.WriteLine($"{val:N}");

            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-CH");
            //Console.WriteLine($"{val:N}");

            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("hi-IN");
            //Console.WriteLine($"{val:N}");

            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-ES");
            //Console.WriteLine($"{val:N}");

            Console.ReadLine();
        }
    }
}
