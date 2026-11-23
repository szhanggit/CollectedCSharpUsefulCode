using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAssemblyLoadingEx
{
    public class PrintMessage : IPrintMessage
    {
        public void PrintM(string Message)
        {
            Console.WriteLine(Message);
        }
    }
}
