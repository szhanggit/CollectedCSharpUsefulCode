using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitStringEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "asd|lfi|s|oj,e";
            var list = str.ToSplitString();
        }
    }
}
