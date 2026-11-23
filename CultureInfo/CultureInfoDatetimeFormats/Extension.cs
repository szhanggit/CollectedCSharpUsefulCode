using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureInfoDatetimeFormats
{
    public static class Extension
    {
        public static string ToDateTimeString(this DateTime dateTime, string lan)
        {
            //1.Front Web调用，因为已经设置了Thread.CurrentThread.CurrentCulture，所以直接ToString
            //2.Back Web调用，需要把lan传递进来，因为你不知道服务器是什么语言
            //3.不能用dateTime.ToString(cultureInfo)，如果是泰国会变成佛历
            var cultureInfo = new CultureInfo(lan);

            return dateTime.ToString($"{cultureInfo.DateTimeFormat.ShortDatePattern} {cultureInfo.DateTimeFormat.LongTimePattern}");
        }

        public static string ToDateString(this DateTime dateTime, string format)
        {
            return dateTime.ToString(format);
        }

        public static DateTime ToDateTime(this string dateTimeString, string format)
        {
            if (string.IsNullOrWhiteSpace(dateTimeString))
            {
                return default(DateTime);
            }

            return DateTime.ParseExact(dateTimeString, format, CultureInfo.InvariantCulture);
        }
    }
}
