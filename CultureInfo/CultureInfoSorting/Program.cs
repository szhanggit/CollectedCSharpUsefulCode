using System;
using System.Globalization;
using System.Collections.Generic;
using System.Threading;

namespace CultureInfoSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("sk-SK");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("sk-SK");

            var words = new List<string> { "čaj", "auto", "drevo", "cibuľa",
                    "čučoriedka", "banán", "čerešňa", "červený", "čierny", "cesnak" };

            words.Sort();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            Console.ReadLine();
        }
    }
}
