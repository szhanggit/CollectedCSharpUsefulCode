using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectService
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            product.ProductId = 1;
            product.ProductName = "MSN";
            product.ProductCode = "CodeMSN";
            product.ModifiedDate = DateTime.Now;
            product.Status = true;

            ObjectService productService = new ObjectService();
            product.ProductId = productService.Assign<int>(product.ProductId, 1);
            product.ProductName = productService.Assign<string>(product.ProductName, "MSN");
            product.ProductCode = productService.Assign<string>(product.ProductCode, "CodeMSN");
            product.ModifiedDate = productService.Assign<DateTime>(product.ModifiedDate, DateTime.Now);
            product.Status = productService.Assign<bool>(product.Status, true);

            bool m = productService.IsModified;
        }
    }
}
