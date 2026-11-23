
namespace Notification.CoreInterface
{
    public class CarrefourCbonRequestDto : BasicRequestDto
    {
        public string MerchantCode { get; set; }
        public string MerchantName { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
    }
}
