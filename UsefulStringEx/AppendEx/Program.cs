using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string s0 = "Good ";
            string s1 = "Morning ";
            string s2 = "Mr";
            string s3 = ".";
            string s4 = " ";
            string s5 = "Black ";
            string s6 = "Smith.";

            string str = Helper.Append(s0, s1, s2, s3, s4, s5, s6);
        }
    }
}
