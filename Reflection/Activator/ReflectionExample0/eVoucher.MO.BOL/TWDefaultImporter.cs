using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.MO.BOL
{
    public abstract class TWDefaultImporter : BaseVoucherImporter
    {
        public TWDefaultImporter()
        {
            GroupName = VoucherImportTemplateType.TWVoucher;
            BufferTableName = "TWDefaultImporter";
            ColumnArray = new string[] { CommonConsts.VoucherNumber, CommonConsts.BalanceAvailable, "GCID" };
            ColumnRegexArray = new string[] { CommonConsts.REGEX_VOUCHERVALIDATION_IN_AMAZON, CommonConsts.REGEX_BALANCEAVAILABLE };
            CheckingData = CheckImportVerificationNumber;
        }

        private DataTable CheckImportVerificationNumber(int programId, string sessionId)
        {
            return new DataTable();
        }
    }
}
