using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.MO.BOL
{
    public class MyCardImporter : BaseVoucherImporter, IVoucherBarCode
    {
        public MyCardImporter()
        {
            GroupName = VoucherImportTemplateType.MyCard;
            BufferTableName = "EXT_MyCard_Buffer";
            ColumnArray = new string[] { CommonConsts.VoucherNumber, CommonConsts.BalanceAvailable, CommonConsts.BARCODE1, CommonConsts.BARCODE2, "TrustStartDate", "TrustEndDate", "PrizeName", "PrizeSn", "PrizePW", "PrizeID" };
            ColumnRegexArray = new string[] { CommonConsts.REGEX_VOUCHERVALIDATION, CommonConsts.REGEX_BALANCEAVAILABLE, CommonConsts.REGEX_BARCODEVALIDATION, CommonConsts.REGEX_BARCODEVALIDATION };
            CheckingData = CheckImportVerificationNumber;
        }

        public void GetImportTableInfo()
        {
            throw new NotImplementedException();
        }

        private DataTable CheckImportVerificationNumber(int programId, string sessionId)
        {
            return new DataTable();
        }
    }
}
