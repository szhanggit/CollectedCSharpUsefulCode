using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HtmlEncodeEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "This string is already encode &lt;0.1";

            Console.WriteLine(HTTPEncodeString(str1));


            string str2 = "This string needs to be encoded <0.01";
            Console.WriteLine(HTTPEncodeString(str2));

            Console.ReadKey();
        }

        public static string HTTPEncodeString(string text)
        {
            /*if (EncodeText(source))
            {
                return source;
            }
            else
            {
                return HttpUtility.HtmlEncode(source);
            }*/

            return IsHtmlEncoded(text) ? text : HttpUtility.HtmlEncode(text);
        }

        public static bool EncodeText(string val)
        {
            string decodedText = HttpUtility.HtmlDecode(val);
            string encodedText = HttpUtility.HtmlEncode(decodedText);

            return encodedText.Equals(val, StringComparison.OrdinalIgnoreCase);

        }

        public static bool IsHtmlEncoded(string text)
        {
            return !text.Equals(HttpUtility.HtmlDecode(text), StringComparison.OrdinalIgnoreCase);
        }
    }
}
