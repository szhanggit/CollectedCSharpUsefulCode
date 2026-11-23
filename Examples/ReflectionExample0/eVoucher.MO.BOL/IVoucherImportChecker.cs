using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.MO.BOL
{
    public interface IVoucherImportChecker : IVoucherImporter
    {
        bool CheckImporter(VoucherImportTemplateType importType);
    }
}
