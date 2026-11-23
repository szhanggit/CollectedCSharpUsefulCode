using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryConvertExcelDateTimeEx
{
    public static class Helper
    {
        public const char Slash = '/';

        public static bool TryConvertExcelDateTime(string source, out DateTime parsedDateTime)
        {
            if (!string.IsNullOrEmpty(source))
            {
                string[] dividedStrings = source.Split(Slash);
                string format = "MM/dd/yy";

                for (int i = 0; i < dividedStrings.Length; i++)
                {
                    var str = dividedStrings[i];

                    if (str.Length == 1)
                    {
                        str = "0" + str; // 2009/2/5 => 2009/02/05
                        dividedStrings[i] = str;
                    }
                    else if (str.Length == 4)
                    {
                        if (i == 0)
                        {
                            format = "yyyy/MM/dd";
                        }
                        else
                        {
                            format = "MM/dd/yyyy";
                        }
                    }
                }

                if (DateTime.TryParseExact(string.Join(Slash.ToString(), dividedStrings), format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out parsedDateTime))
                {
                    return true;
                }
            }

            parsedDateTime = DateTime.MinValue;
            return false;
        }
    }
}
