using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriEscapeDataStringEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string body = "<html>";
            string encodedBody = Uri.EscapeDataString(body);
        }
    }
}
