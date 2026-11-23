using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTimeBOL
{
    public static class DateTimeHelper
    {
        public static DateTime SqlMinValue(this DateTime sqlDateTime)
        {
            return new DateTime(1900, 01, 01, 00, 00, 00);
        }

        public static DateTime SqlMaxValue(this DateTime sqlDateTime)
        {
            return new DateTime(3999, 01, 01, 00, 00, 00);
        }

        public static int GetDate(this DateTime dateTime)
        {
            return int.Parse(dateTime.Date.ToString(Constant.DateFormat));
        }

        public static DateTime GetSqlValidDateTime(this DateTime sqlDateTime, bool MinValue)
        {
            return MinValue ? (sqlDateTime < SqlMinValue(sqlDateTime) || sqlDateTime > SqlMaxValue(sqlDateTime) ? SqlMinValue(sqlDateTime) : sqlDateTime)
                : (sqlDateTime > SqlMaxValue(sqlDateTime) || sqlDateTime < SqlMinValue(sqlDateTime) ? SqlMaxValue(sqlDateTime) : sqlDateTime);
        }
    }
}
