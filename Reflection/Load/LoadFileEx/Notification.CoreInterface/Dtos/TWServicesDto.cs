
namespace Notification.CoreInterface
{
    public class TWServicesDto : BasicRequestDto
    {
        public string ClientCode { get; set; }
        public string MerchantCode { get; set; }
        public string MerchantName { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
    }
}
