using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.MO.BOL
{
    public class TWIQiYiImporter : BaseVoucherImporter
    {
        public TWIQiYiImporter()
        {
            GroupName = VoucherImportTemplateType.TWIQiYiVoucher;
            BufferTableName = "EXT_TW_IQiYi_Buffer";
            ColumnArray = new string[] { CommonConsts.VoucherNumber, CommonConsts.BalanceAvailable, "ActivationCode" };
            ColumnRegexArray = new string[] { CommonConsts.REGEX_VOUCHERVALIDATION, CommonConsts.REGEX_BALANCEAVAILABLE, CommonConsts.REGEX_BARCODEVALIDATION };
            CheckingData = CheckImportVerificationNumber;
        }

        private DataTable CheckImportVerificationNumber(int programId, string sessionId)
        {
            return new DataTable();
        }
    }
}
