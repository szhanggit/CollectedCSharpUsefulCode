using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexSplitEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "asdf\r\nsdfasd;\r\nflkjalsd\r\nfkj;lasdk\r\njfl;ak\r\njsdfl;kj\r\nasdf";
            string[] sArray = Regex.Split(input, "\r\n");
        }
    }
}
