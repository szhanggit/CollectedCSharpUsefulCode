using eVoucher.MO.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ReflectionExample0
{
    class Program
    {
        static void Main(string[] args)
        {
            var import = new VoucherImporterFactory().Create(VoucherImportTemplateType.MyCard);
            import.ImportVoucher(new DataTable(), new DateTime(), 123, 3);
        }
    }
}
