using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeperateEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "adsf|a|sd|fkl|rje|kas|fkl|ja|he|srk|hja|f";
            List<string> list = Helper.Seperate(str);
        }
    }
}
