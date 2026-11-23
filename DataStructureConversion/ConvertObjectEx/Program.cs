using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertObjectEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            p.Id = 12;
            p.Price = 32.34m;
            p.ProductCode = "asdfdasf";
            p.ProductName = "adfdasf";
            p.ProductType = 1;

            Product1 p2 = p.Convert<Product1>();
        }
    }
}
