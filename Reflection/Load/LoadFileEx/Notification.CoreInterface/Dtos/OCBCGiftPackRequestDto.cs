
namespace Notification.CoreInterface
{
    public class OCBCGiftPackRequestDto : BasicRequestDto
    {
        public string VoucherGUID { get; set; }
        public string MerchantCode { get; set; }
        public string MerchantName { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string TranAmount { get; set; }
        public string TranBalance { get; set; }
        public string Balance { get; set; }
        //... these are not used, yet...
        public string TranCode { get; set; }
        public string TranType { get; set; }
        public string ProductType { get; set; }

    }
}
