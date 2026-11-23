using System;
using System.IO;
using System.Globalization;

namespace InvariantCulture2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*using var sr = new StreamReader(@"C:\Users\Jano\Documents\tmp\dates.dat");
            string contents = sr.ReadToEnd();
            string[] dateStrings = contents.Split('|');

            Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.Name}");

            foreach (var dateStr in dateStrings)
            {
                DateTime dateVal;
                if (DateTime.TryParse(dateStr, CultureInfo.InvariantCulture,
                                      DateTimeStyles.None, out dateVal))
                {
                    Console.WriteLine("The date is {0:D}", dateVal);
                }
                else
                {
                    Console.WriteLine("ERROR: Unable to parse {0}", dateStr);
                }
            }

            Console.WriteLine();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("sk-SK");
            Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.Name}");

            foreach (var dateStr in dateStrings)
            {
                DateTime dateVal;
                if (DateTime.TryParse(dateStr, CultureInfo.InvariantCulture,
                                      DateTimeStyles.None, out dateVal))
                {
                    Console.WriteLine("Dátum je {0:D}", dateVal);
                }
                else
                {
                    Console.WriteLine("ERROR: Unable to parse {0}", dateStr);
                }
            }

            Console.ReadLine();*/
        }
    }
}
