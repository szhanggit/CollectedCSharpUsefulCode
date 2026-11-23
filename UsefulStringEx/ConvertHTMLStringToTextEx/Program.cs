using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConvertHTMLStringToTextEx
{
    class Program
    {
        public static string ConvertHTMLStringToText(string htmlString)
        {
            string resultString = string.Empty;
            if (string.IsNullOrEmpty(htmlString))
                return string.Empty;
            else
                resultString = htmlString;

            resultString = Regex.Replace(resultString, @"<li>", "●", RegexOptions.IgnoreCase);
            resultString = Regex.Replace(resultString, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            resultString = Regex.Replace(resultString, @"&(nbsp);", " ", RegexOptions.IgnoreCase);
            resultString = Regex.Replace(resultString, @"&(rarr);", "→", RegexOptions.IgnoreCase);
            resultString = Regex.Replace(resultString, @"([\r\n\t]+)[\s]+", "", RegexOptions.IgnoreCase);
            resultString = Regex.Replace(resultString, @"●", "\r\n●", RegexOptions.IgnoreCase);

            if (resultString.IndexOf('\n') == 1)
                resultString = resultString.Substring(2);



            return resultString;
        }

        static void Main(string[] args)
        {
        }
    }
}
