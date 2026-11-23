using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeFormat
{
    public static class Helper
    {
        private const string DateFormat = "yyyyMMdd";
        public static int GetLocalDate(Nullable<DateTime> dateTime)
        {
            int localDate = 0;

            if (dateTime.HasValue)
            {
                string str = dateTime.Value.ToString(DateFormat, CultureInfo.InvariantCulture);
                int.TryParse(dateTime.Value.ToString(DateFormat, CultureInfo.InvariantCulture), out localDate);
            }

            return localDate;
        }
    }
}
