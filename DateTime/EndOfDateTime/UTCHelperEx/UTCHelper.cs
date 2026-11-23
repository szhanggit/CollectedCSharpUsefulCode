using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTCHelperEx
{
    public class UTCHelper
    {
        /// <summary>
        /// convert to UTC GMT time by local time and timezone config(profile)
        /// </summary>
        /// <param name="localTime">local plan/Now time</param>
        /// <param name="timezoneOffset">local timezoneOffset ex. chinese timezoneOffset is 08:00 </param>
        /// <returns></returns>
        public static DateTime ToUTCTime(DateTime localTime, string timezoneOffset)
        {
            try
            {
                TimeSpan timeSpan = TimeSpan.Parse(timezoneOffset);
                return localTime - timeSpan;
            }
            catch (Exception ex)
            {
                //log4net.ILog log = log4net.LogManager.GetLogger("ToUTCTime");
                //log.Debug(ex.Message);
                return DateTime.Parse("1900-01-01 00:00:01");
            }
        }

        /// <summary>
        /// get local time from UTC GMT according to timeuser’s timezone config(profile)
        /// </summary>
        /// <param name="UTCTime">GMT UTC time from database</param>
        /// <param name="timezoneOffset">local Time Zone offset from users  08:00</param>
        /// <returns>local time,format like 2014/3/20 15:26:20</returns>
        public static DateTime ToLocalTime(DateTime UTCTime, string timezoneOffset)
        {
            try
            {
                TimeSpan timeSpan = TimeSpan.Parse(timezoneOffset);
                return UTCTime + timeSpan;
            }
            catch (Exception ex)
            {
                // log4net.ILog log = log4net.LogManager.GetLogger("ToUTCTime");
                //log.Debug(ex.Message);
                return DateTime.Parse("1900-01-01 00:00:01");
            }

        }

        public static int GetUtcTimestamp(DateTime date)
        {
            var timestamp = (int)(date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            DateTime test = GetUtcDateTime(timestamp);
            test = test.ToLocalTime();
            return timestamp;
        }

        private static DateTime GetUtcDateTime(int timestamp)
        {
            return (new DateTime(1970, 1, 1)).AddSeconds(timestamp);
        }
    }
}
