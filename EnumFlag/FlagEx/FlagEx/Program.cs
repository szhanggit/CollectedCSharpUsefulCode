using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = (int)ProductTag.Delivery + (int)ProductTag.Digital;
            Dictionary<string, bool> dic = ProductTagHelper.GetProductTagValue(value);
            Console.WriteLine(ProductTag.Digital.ToString());
            Console.ReadKey();
        }
    }
}
