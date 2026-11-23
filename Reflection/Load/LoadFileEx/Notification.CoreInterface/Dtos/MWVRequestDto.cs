
namespace Notification.CoreInterface
{
    public class MWVRequestDto : BasicRequestDto
    {
        public string TranCode { get; set; }
        public string VoucherGUID { get; set; }
        public string TranType { get; set; }
        public string ProductType { get; set; }
        public string TranAmount { get; set; }
        public string BalanceAvailable { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
    }
}
