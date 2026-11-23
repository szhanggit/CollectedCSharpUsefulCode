
namespace Notification.CoreInterface
{
    public class LINERequestDto
    {
        public string ProgramCode { get; set; }
        public string VoucherNo { get; set; }
        public byte Status { get; set; }
        public string ActionDate { get; set; }
        public string MerchantCode { get; set; }
        public string MerchantName { get; set; }
        public string ShopName { get; set; }
        public string ShopCode { get; set; }
        public string TranAmout { get; set; }
        public string TranBalance { get; set; }
        public string TranCode { get; set; }
        public string Balance { get; set; }
        public string MasterVoucherNo { get; set; }
        public string MasterProgramCode { get; set; }
        public string RSV1 { get; set; }
        public string RSV2 { get; set; }
        public string RSV3 { get; set; }
    }
}
