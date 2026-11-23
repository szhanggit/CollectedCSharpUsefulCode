using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.MO.BOL
{
    public class TWSevenElevenImporter : BaseVoucherImporter
    {
        public TWSevenElevenImporter()
        {
            GroupName = VoucherImportTemplateType.TWSevenElevenVoucher;
            BufferTableName = "EXT_TW_SEBarcode_Temp";
            ColumnArray = new string[] { CommonConsts.VoucherNumber, CommonConsts.BalanceAvailable, CommonConsts.BARCODE1, CommonConsts.BARCODE2, "TrustStartDate", "TrustEndDate" };
            ColumnRegexArray = new string[] { CommonConsts.REGEX_VOUCHERVALIDATION, CommonConsts.REGEX_BALANCEAVAILABLE, CommonConsts.REGEX_BarcodeCanNull, CommonConsts.REGEX_BARCODEVALIDATION };
            CheckingData = CheckImportVerificationNumber;
        }

        private DataTable CheckImportVerificationNumber(int programId, string sessionId)
        {
            return new DataTable();
        }
    }
}
