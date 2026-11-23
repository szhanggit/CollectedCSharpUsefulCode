using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCloneEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            p.Id = 12;
            p.ProductCode = "adsfasd";
            p.ProductName = "adfads";
            p.Price = 23.43m;
            p.ProductType = 2;

            Product p2 = p.DeepClone<Product>();
        }
    }
}
