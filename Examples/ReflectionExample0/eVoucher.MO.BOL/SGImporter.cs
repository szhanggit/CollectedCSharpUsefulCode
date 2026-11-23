using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.MO.BOL
{
    public class SGImporter : BaseVoucherImporter
    {
        public SGImporter()
        {
            GroupName = VoucherImportTemplateType.SGVoucher;
            BufferTableName = "EXT_SG_SerialNumber_Buffer";
            ColumnArray = new string[] { CommonConsts.VoucherNumber, CommonConsts.VerificationNumber, CommonConsts.BalanceAvailable };
            ColumnRegexArray = new string[] { @"^[0-9a-zA-Z\\-]{6,50}$", CommonConsts.REGEX_VerificationNumber, CommonConsts.REGEX_BALANCEAVAILABLE };
            CheckingData = CheckImportVerificationNumber;
        }

        private DataTable CheckImportVerificationNumber(int programId, string sessionId)
        {
            return new DataTable();
        }
    }
}
