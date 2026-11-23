using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumConvert
{
    public class TransactionRequest
    {
        public string AccountNumber { get; set; }
        public string ProgramCode { get; set; }
        public string MerchantCode { get; set; }
        public string TerminalSSN { get; set; }
        public string TranTerminalDateTime { get; set; }
        public string ShopCode { get; set; }
        public string TerminalCode { get; set; }
        public short TranType { get; set; }
        public Nullable<int> TranAmount { get; set; }
        public string CallerIP { get; set; }
        public string Channel { get; set; }
        public string TranCodeRef { get; set; }
        public string Checksum { get; set; }
        public TransactionEncoding Encoding { get; set; }
        public string Rsv1 { get; set; }
        public string Rsv2 { get; set; }
        public string Rsv3 { get; set; }
        public byte Version { get; set; }
        public int? BusinessDay { get; set; }
        public string PinCode { get; set; }
        public long? StartSN { get; set; }
        public long? EndSN { get; set; }

        //private string ChecksumInput
        //{
        //    get
        //    {
        //        return Helper.Append(AccountNumber, Constant.EqualSign, Channel, Constant.EqualSign, MerchantCode, Constant.EqualSign, ProgramCode, Constant.EqualSign, ShopCode, Constant.EqualSign, TerminalCode, Constant.EqualSign, TerminalSSN,
        //            Constant.EqualSign, TranAmount, Constant.EqualSign, TranCodeRef, Constant.EqualSign, DateTime.Parse(TranTerminalDateTime).ToString("yyyyMMddHHmmss"), Constant.EqualSign, TranType);
        //    }
        //}

        //public void CalcChecksum(string value)
        //{
        //    Checksum = Md5Helper.Encrypt(ChecksumInput, value);
        //}

        //public bool IsChecksumValid(string value)
        //{
        //    return Md5Helper.VerifyMd5Hash(ChecksumInput, value, Checksum);
        //}

        //public bool CheckValidWithNoTranAmount(string value)
        //{
        //    //为解决TranAmount开始为null，后来赋值，checksum对应不上
        //    var checksumInput = Helper.Append(AccountNumber, Constant.EqualSign, Channel, Constant.EqualSign, MerchantCode, Constant.EqualSign, ProgramCode, Constant.EqualSign, ShopCode, Constant.EqualSign, TerminalCode, Constant.EqualSign, TerminalSSN,
        //            Constant.EqualSign, Constant.EqualSign, TranCodeRef, Constant.EqualSign, DateTime.Parse(TranTerminalDateTime).ToString("yyyyMMddHHmmss"), Constant.EqualSign, TranType);
        //    return Md5Helper.VerifyMd5Hash(checksumInput, value, Checksum);
        //}
    }
}
