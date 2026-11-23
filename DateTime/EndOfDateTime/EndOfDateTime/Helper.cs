using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndOfDateTime
{
    public static class Helper
    {
        public static DateTime ParseToEndDateTime(this string dateTime, DateTime defaultDateTime)
        {
            DateTime result = defaultDateTime.Date;
            if (DateTime.TryParse(dateTime, out result))
            {
                result = result.AddDays(1).AddSeconds(-1);
            }

            return result;
        }

        public static DateTime ParseToDateTime(this string dateTime, DateTime defaultDateTime)
        {
            DateTime result = defaultDateTime;
            DateTime.TryParse(dateTime, out result);

            return result;
        }
    }
}
