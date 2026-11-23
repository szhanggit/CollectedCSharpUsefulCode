using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrConcatenateEx
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> AccountList = new List<string>();
            AccountList.Add("asdfasd1");
            AccountList.Add("asdfasd2");
            AccountList.Add("asdfasd3");
            AccountList.Add("asdfasd4");
            AccountList.Add("asdfasd5");

            string result = string.Join(",", AccountList.ToArray().Select(a => "'" + a + "'"));
        }
    }
}
