using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TroubleMakerString
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "www.google.ca";//It could come from XML.
            HttpUtility.HtmlEncode(address.Replace("\u200B", ""));//将字符串转换为 HTML 编码字符串。
        }
    }
}
