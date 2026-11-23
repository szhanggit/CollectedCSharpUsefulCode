using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversion
{
    /*
     https://www.tutorialspoint.com/csharp/csharp_type_conversion.htm
         */
    class Program
    {
        static void Main(string[] args)
        {
            decimal d = "34.67".ParseToDecimal();
            int i = "3".ParseToInt();
            int i2 = "4".ToIn32(0);

        }
    }
}
