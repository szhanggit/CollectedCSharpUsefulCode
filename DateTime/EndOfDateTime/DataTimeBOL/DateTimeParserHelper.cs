using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataTimeBOL
{
    public class DateTimeParserHelper
    {
        private static readonly Lazy<DateTimeParserHelper> instance = new Lazy<DateTimeParserHelper>(() => new DateTimeParserHelper(), LazyThreadSafetyMode.ExecutionAndPublication);

        private DateTimeParserHelper()
        {

        }

        static DateTimeParserHelper() { }

        public static DateTimeParserHelper Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public string MakeSingleStrDoubleStr(string ori)
        {
            string transed;
            if (ori.Length == 1)
            {
                transed = "0" + ori;
            }
            else if (ori.Length == 2)
            {
                transed = ori;
            }
            else
            {
                transed = ori;
            }

            return transed;
        }

        public string ParseDateTimeString(string DateTimeStr)
        {
            string result = string.Empty;
            string[] argumetents = DateTimeStr.Split(' ');
            string[] DateStr;
            string[] TimeStr;
            string month = string.Empty;
            string day = string.Empty;
            string year = string.Empty;
            int hour = 0;
            string hourstr = string.Empty;
            string minute = string.Empty;
            string second = string.Empty;
            string APM = string.Empty;
            if (argumetents.Count() > 0)
            {
                DateStr = argumetents[0].Split('/');
                if (DateStr.Count() == 3)
                {
                    month = MakeSingleStrDoubleStr(DateStr[0]);
                    day = MakeSingleStrDoubleStr(DateStr[1]);
                    year = DateStr[2];
                }
                TimeStr = argumetents[1].Split(':');
                if (TimeStr.Count() == 3)
                {
                    int.TryParse(TimeStr[0], out hour);
                    minute = MakeSingleStrDoubleStr(TimeStr[1]);
                    second = MakeSingleStrDoubleStr(TimeStr[2]);
                }
                APM = argumetents[2];
                if (APM == "PM")
                {
                    hour = hour + 12;
                }
                else if (APM == "AM" && TimeStr[0] == "12")
                {
                    hour = 0;
                }
                else
                {

                }
                hourstr = MakeSingleStrDoubleStr(hour.ToString());
                result = $"{year}-{month}-{day} {hourstr}:{minute}:{second}";
                return result;
            }
            else
            {
                return string.Empty;
            }
        }

        public string ParseDateString(string DateTimeStr)
        {
            string result = string.Empty;
            string[] DateStr;
            string month = string.Empty;
            string day = string.Empty;
            string year = string.Empty;
            if (!string.IsNullOrEmpty(DateTimeStr))
            {
                DateStr = DateTimeStr.Split('/');
                if (DateStr.Count() == 3)
                {
                    month = MakeSingleStrDoubleStr(DateStr[0]);
                    day = MakeSingleStrDoubleStr(DateStr[1]);
                    year = DateStr[2];
                }

                result = $"{year}-{month}-{day}";
                return result;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
