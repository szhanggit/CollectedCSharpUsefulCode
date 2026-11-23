using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListCultures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("{0,-15}{0,-5}{0,-45}{0,-40}", "Culture", "ISO", "Display name", "English Name");

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                Console.Write("{0,-15}", ci.Name);
                Console.Write("{0,-5}", ci.TwoLetterISOLanguageName);
                Console.Write("{0,-45}", ci.DisplayName);
                Console.WriteLine("{0,-40}", ci.EnglishName);
            }

            Console.ReadLine();
        }
    }
}
