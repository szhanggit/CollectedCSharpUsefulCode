using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulStringEx
{
    class Program
    {
        private static char Slash = '/';
        private static char BackSlash = '\\';

        public static string StringBetween(string text, string firstString, string lastString)
        {
            int posA = text.IndexOf(firstString, StringComparison.InvariantCultureIgnoreCase);
            int posB = text.IndexOf(lastString, StringComparison.InvariantCultureIgnoreCase);
            if (posA == -1 || posB == -1)
            {
                return string.Empty;
            }
            int adjustedPosA = posA + firstString.Length;
            if (adjustedPosA > posB)
            {
                return string.Empty;
            }
            return text.Substring(adjustedPosA, posB - adjustedPosA);
        }

        public static string StringBefore(string text, string beforeString)
        {
            int posA = text.IndexOf(beforeString, StringComparison.InvariantCultureIgnoreCase);
            if (posA == -1)
            {
                return string.Empty;
            }
            return text.Substring(0, posA);
        }

        public static string StringAfter(string text, string afterString)
        {
            int posA = text.IndexOf(afterString, StringComparison.InvariantCultureIgnoreCase);
            if (posA == -1)
            {
                return string.Empty;
            }
            int adjustedPosA = posA + afterString.Length;
            if (adjustedPosA > text.Length)
            {
                return string.Empty;
            }
            return text.Substring(adjustedPosA);
        }

        public static string CombineUrl(params string[] segments)
        {
            string result = null;

            for (int i = 0; i < segments.Length; i++)
            {
                result += segments[i];

                if (!segments[i].EndsWith(Slash.ToString()) && !segments[i].EndsWith(BackSlash.ToString()) && i < segments.Length - 1)
                {
                    result += Slash;
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            string text = "aaaaadsssfasssdfadsssfzzzz";
            string firstString = "aaaa";
            string lastString = "zzzz";
            string between = StringBetween(text, firstString, lastString);
            string before = StringBefore(text, "sss");
            string after = StringAfter(text, "sss");

            string url = CombineUrl("download", "voucher", "file.xlsx");


            string username = "stevenzhang1981cn@google.com";
            bool a = username.EndsWith("@google.com");
            bool b = username.StartsWith("stevenzhang");
            string SourceBatchNumbers = "ad|sf|sdf|sfa|fa|sdfd|";
            string result = SourceBatchNumbers.TrimEnd('|');
        }
    }
}
