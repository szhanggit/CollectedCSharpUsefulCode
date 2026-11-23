using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.MO.BOL
{
    public class Books_PrepaidImporter : BaseVoucherImporter
    {
        public Books_PrepaidImporter()
        {
            GroupName = VoucherImportTemplateType.BOOKS_Prepaid;
            BufferTableName = "EXT_BOOKS_Prepaid_Buffer";
            ColumnArray = new string[] { CommonConsts.VoucherNumber, CommonConsts.BalanceAvailable, "TrustStartDate", "TrustEndDate" };
            ColumnRegexArray = new string[] { CommonConsts.REGEX_VOUCHERVALIDATION, CommonConsts.REGEX_BALANCEAVAILABLE, CommonConsts.REGEX_DateTime, CommonConsts.REGEX_DateTime };
            CheckingData = CheckImportVerificationNumber;
        }

        private DataTable CheckImportVerificationNumber(int programId, string sessionId)
        {
            return new DataTable();
        }
    }
}
