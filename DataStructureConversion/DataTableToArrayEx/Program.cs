using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableToArrayEx
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
            table.Rows.Add(16, "Coak1", "CK000001", 344.23, 2);
            table.Rows.Add(17, "Coak2", "CK000002", 345.23, 2);
            table.Rows.Add(18, "Coak3", "CK000003", 346.23, 2);
            table.Rows.Add(19, "Coak4", "CK000004", 347.23, 2);
            table.Rows.Add(20, "Coak5", "CK000005", 348.23, 2);
            table.Rows.Add(21, "Coak6", "CK000006", 349.23, 2);
            table.Rows.Add(22, "Coak7", "CK000007", 324.23, 2);
            table.Rows.Add(23, "Coak8", "CK000008", 334.23, 2);
            table.Rows.Add(24, "Coak9", "CK000009", 354.23, 2);

            var arr = table.AsEnumerable().Select(dr => new Product {
                Id = dr.Field<int>("Id"),
                ProductName = dr.Field<string>("ProductName"),
                ProductCode = dr.Field<string>("ProductCode"),
                Price = dr.Field<decimal>("Price"),
                ProductType = dr.Field<int>("ProductType")
            }).ToArray();
        }
    }
}
