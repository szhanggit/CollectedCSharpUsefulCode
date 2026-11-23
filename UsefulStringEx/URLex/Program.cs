using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLex
{
    class Program
    {
        static void Main(string[] args)
        {
            string BaseDir = AppDomain.CurrentDomain.BaseDirectory;
            if (!BaseDir.EndsWith("\\"))
            {
                BaseDir = BaseDir + "\\";
            }                
        }
    }
}
