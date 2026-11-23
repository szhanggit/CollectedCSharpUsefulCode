using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public static class CommonRegularExpression
    {
        public const string VoucherNumber = "[0-9a-zA-Z-]{5,27}";
        public const string ProgramCode = @"^\d{1,50}$";
        public const string OrderNumber = @"^\d{12}$";
        public const string ValidEmail = @"^([0-9a-zA-Z_]+[-._+&amp;])*[0-9a-zA-Z_.-]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";
        public const string ValidMobileNo = @"^\d{10}$"; // 10 characters, all numeric


        public const string EMAIL = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
        public const string CHECKSUM = "^[a-fA-F0-9]{32}$";
        public const string RESV1 = "^[a-zA-Z0-9]{1,50}$";
        public const string RESV2 = "^[a-zA-Z0-9]{1,50}$";
        public const string RESV3 = "^[a-zA-Z0-9]{1,50}$";
        public const string VOUCHERTYPE = "^G|P$";
        public const string VOUCHERNUMBER = "^[a-zA-Z0-9]{5,50}$";
        public const string TERMINALSSN = "^[A-Za-z0-9]{1,50}$";
        public const string PINCODE = "^[a-fA-F0-9]{8}$";
        public const string MERCHANTCODE = @"^\d{1,50}$";
        public const string SHOPCODE = "^[A-Za-z0-9]{1,50}$";
        public const string TRANTIME = "^[2][0][1-9][1-9][0-1][0-9][0-3][0-9][0-2][0-9][0-5][0-9][0-5][0-9]$";
        public const string TRANCODE = "^[a-fA-F0-9]{8}-{0,1}([a-fA-F0-9]{4}-{0,1}){3}[a-fA-Z0-9]{12}$";
        public const string REPORTTYPE = "^T|R$";
    }
}
