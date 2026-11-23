using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitStringEx
{
    public static class Helper
    {
        public static string ToSplitString(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            char[] charArray = str.ToCharArray();
            StringBuilder sb = new StringBuilder(charArray.Length);
            for (int i = 0; i < charArray.Length; i++)
            {
                char item = charArray[i];
                if (item >= 65 && item <= 90)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(' ');
                    }
                }

                sb.Append(item);
            }
            return sb.ToString();
        }
    }
}
