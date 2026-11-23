using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int ProductId;
            Product p = new Product();
            p.ProductId = 12;
            p.SetKey("ProductCode", "K000008");
            bool flag = int.TryParse(p.GetKey("ProductId").ToString(), out ProductId);
        }
    }
}
