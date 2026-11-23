using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversion
{
    public static class Helper
    {
        public static decimal ParseToDecimal(this string value)
        {
            decimal parsedDecimal = 0;

            decimal.TryParse(value, out parsedDecimal);

            return parsedDecimal;
        }

        public static int ParseToInt(this string value)
        {
            int parsedInt = 0;

            int.TryParse(value, out parsedInt);

            return parsedInt;
        }

        public static int ToIn32(this string input, int defaultValue = default(int))
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                int.TryParse(input, out defaultValue);
            }
            return defaultValue;
        }

        public static int? ToIn32Nullable(this string input)
        {
            int? temp = null;
            if (!string.IsNullOrWhiteSpace(input))
            {
                int value;
                if (int.TryParse(input, out value))
                {
                    temp = value;
                }
            }
            return temp;
        }

        public static long ToIn64(this string input, long defaultValue = default(long))
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                long.TryParse(input, out defaultValue);
            }
            return defaultValue;
        }

        public static long? ToIn64Nullable(this string input)
        {
            long? temp = null;
            if (!string.IsNullOrWhiteSpace(input))
            {
                long value;
                if (long.TryParse(input, out value))
                {
                    temp = value;
                }
            }
            return temp;
        }

        public static decimal ToDecimal(this string input, decimal defaultValue = default(decimal))
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                decimal.TryParse(input, out defaultValue);
            }
            return defaultValue;
        }

        public static decimal? ToDecimalNullable(this string input)
        {
            decimal? temp = null;
            if (!string.IsNullOrWhiteSpace(input))
            {
                decimal value;
                if (decimal.TryParse(input, out value))
                {
                    temp = value;
                }
            }
            return temp;
        }

        public static float ToFloat(this string input, float defaultValue = default(float))
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                float.TryParse(input, out defaultValue);
            }
            return defaultValue;
        }

    }
}
