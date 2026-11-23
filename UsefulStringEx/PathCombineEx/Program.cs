using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCombineEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string OrderFileDirectory = @"C:\";
            string file = "file.txt";
            string fullPath = Path.Combine(OrderFileDirectory, file);
        }
    }
}
