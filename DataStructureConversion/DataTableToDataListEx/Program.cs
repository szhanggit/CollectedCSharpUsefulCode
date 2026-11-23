using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableToDataListEx
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(Int32));
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("ProductCode", typeof(string));
            table.Columns.Add("Price", typeof(decimal));
            table.Columns.Add("ProductType", typeof(int));

            // Step 3: here we add rows.
            table.Rows.Add(12, "FriedChicken", "FC00001", 213.23, 1);
            table.Rows.Add(16, "Coak", "CK000001", 344.23, 2);

            DataTableToDataListHelper dtt = new DataTableToDataListHelper();
            var list = dtt.ConvertDataTableToList<Product>(table);
        }
    }
}
