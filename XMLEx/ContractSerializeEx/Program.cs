using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractSerializeEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product
            {
                ProductId = 12,
                ProductName = "KFC",
                ProductCode = "K000007",
                ProductType = 2,
                Price = 23.34m,
                shopList = new List<Shop> {
                    new Shop{ ShopId = 2, ShopName = "S0" },
                    new Shop{ ShopId = 3, ShopName = "S1" },
                    new Shop{ ShopId = 4, ShopName = "S2" },
                    new Shop{ ShopId = 5, ShopName = "S3" },
                }
            };

            string xmlStr = Helper.ContractSerialize<Product>(p);
            Product obj = Helper.ContractDeserialize<Product>(xmlStr);
        }
    }
}
