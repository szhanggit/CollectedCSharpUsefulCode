using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingEx
{
    public class Helper
    {
        public static bool IsUnicode(string input)
        {
            var asciiBytesCount = Encoding.ASCII.GetByteCount(input);
            var unicodBytesCount = Encoding.UTF8.GetByteCount(input);
            return asciiBytesCount != unicodBytesCount;
        }

        public static bool StringCompareEncoding(string source, string dest)
        {
            int sour = EncodeFunc(source);
            int des = EncodeFunc(dest);
            return (sour == des) ? true : false;
        }

        private static int EncodeFunc(string input)
        {
            int total = 0;
            char[] arr = input.ToArray();
            foreach (char c in arr)
            {
                total = total + c;
            }

            return total;
        }
    }
}
