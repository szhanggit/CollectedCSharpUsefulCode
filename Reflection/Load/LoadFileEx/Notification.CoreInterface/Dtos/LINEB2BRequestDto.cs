
namespace Notification.CoreInterface
{
    public class LINEB2BRequestDto
    {
        public string ProgramCode { get; set; }
        public string VoucherNo { get; set; }
        public string MerchantCode { get; set; }
        public string MerchantName { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string TerminalCode { get; set; }
        public byte Status { get; set; }
        public string ActionDate { get; set; }
    }
}
