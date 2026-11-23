using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IProcessor processor = ProcessorFactory.Create(ESBMessageType.Media);
        }
    }
}
