using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSectionEx1
{
    /*
     https://www.c-sharpcorner.com/article/four-ways-to-read-configuration-setting-in-c-sharp/
         */
    class Program
    {
        public static void GetConfigurationValue()
        {
            var title = ConfigurationManager.AppSettings["title"];
            var language = ConfigurationManager.AppSettings["language"];

            Console.WriteLine(string.Format("'{0}' project is created in '{1}' language ", title, language));
        }

        static void Main(string[] args)
        {
            GetConfigurationValue();
            Console.ReadKey();
        }
    }
}
