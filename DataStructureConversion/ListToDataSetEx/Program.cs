using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListToDataSetEx
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product> {
                new Product{ Id = 12, Price = 23m, ProductCode = "asdf12", ProductName = "adsfasdf", ProductType = 1},
                new Product{ Id = 13, Price = 23m, ProductCode = "asdf13", ProductName = "adsfasdf", ProductType = 1},
                new Product{ Id = 14, Price = 23m, ProductCode = "asdf14", ProductName = "adsfasdf", ProductType = 1},
                new Product{ Id = 15, Price = 23m, ProductCode = "asdf15", ProductName = "adsfasdf", ProductType = 1},
                new Product{ Id = 16, Price = 23m, ProductCode = "asdf16", ProductName = "adsfasdf", ProductType = 1},
                new Product{ Id = 17, Price = 23m, ProductCode = "asdf17", ProductName = "adsfasdf", ProductType = 1},
                new Product{ Id = 18, Price = 23m, ProductCode = "asdf18", ProductName = "adsfasdf", ProductType = 1},
                new Product{ Id = 19, Price = 23m, ProductCode = "asdf19", ProductName = "adsfasdf", ProductType = 1},
            };

            var ds = Helper.ConvertToDataSet<Product>(list);
        }
    }
}
