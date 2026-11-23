using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDataTableEx
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product> {
                new Product{ Id = 12, ProductName = "FriedChicken", ProductCode = "FC00001", Price = 213.23m, ProductType = 1 },
                new Product{ Id = 16, ProductName = "Coak", ProductCode = "CK000001", Price = 344.23m, ProductType = 2 },
            };

            var dt = list.ToDataTable<Product>();
        }
    }
}
