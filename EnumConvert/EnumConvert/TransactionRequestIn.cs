using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumConvert
{
    public class TransactionRequestIn
    {
        public TransactionRequestIn()
        {

        }

        public string AccountNumber { get; set; }
        public string ProgramCode { get; set; }
        public string MerchantCode { get; set; }
        public string TerminalSSN { get; set; }
        public string TranTerminalDateTime { get; set; }
        public string ShopCode { get; set; }
        public string TerminalCode { get; set; }
        public string TranType { get; set; }
        public string TranAmount { get; set; }
        public string Channel { get; set; }
        public string TranCodeRef { get; set; }
        public string Checksum { get; set; }
        public string Encoding { get; set; }
        public string Rsv1 { get; set; }
        public string Rsv2 { get; set; }
        public string Rsv3 { get; set; }
        public string PinCode { get; set; }
        public string Version { get; set; }
        public DateTime TerminalDateTime { get; set; }

        public override string ToString()
        {
            return Helper.Serialize<TransactionRequestIn>(this);
        }
    }
}
