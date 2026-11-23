using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSectionEx3
{
    class Program
    {
        /*
         https://www.c-sharpcorner.com/article/four-ways-to-read-configuration-setting-in-c-sharp/
             */
        public static void GetConfigurationUsingCustomClass()
        {
            var productSettings = ConfigurationManager.GetSection("ProductSettings") as ProductSettings;
            if (productSettings == null)
            {
                Console.WriteLine("Product Settings are not defined");
            }
            else
            {
                var productNumber = productSettings.DellFeatures.ProductNumber;
                var productName = productSettings.DellFeatures.ProductName;
                var color = productSettings.DellFeatures.Color;
                var warranty = productSettings.DellFeatures.Warranty;

                Console.WriteLine("Product Number = " + productNumber);
                Console.WriteLine("Product Name = " + productName);
                Console.WriteLine("Product Color = " + color);
                Console.WriteLine("Product Warranty = " + warranty);
            }
        }

        static void Main(string[] args)
        {
            GetConfigurationUsingCustomClass();
        }
    }
}
