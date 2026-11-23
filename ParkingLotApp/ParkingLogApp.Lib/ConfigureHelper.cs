using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.Lib
{
    public static class ConfigureHelper
    {
        public static string ConfigStringValue(this string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static bool ConfigBoolValue(this string key)
        {
            bool result = false;
            string value = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrWhiteSpace(value))
            {
                bool.TryParse(value, out result);
            }

            return result;
        }

        public static int ConfigIntValue(this string key, int defaultValue)
        {
            int value = 0;
            if (int.TryParse(ConfigurationManager.AppSettings[key], out value))
            {
                defaultValue = value;
            }
            return defaultValue;
        }

        public static List<string> ConfigListValue(this string key)
        {
            var tempStr = ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrWhiteSpace(tempStr))
                return tempStr.Split(new char[] { ',' }).ToList();
            else
                return new List<string>();
        }
    }
}
