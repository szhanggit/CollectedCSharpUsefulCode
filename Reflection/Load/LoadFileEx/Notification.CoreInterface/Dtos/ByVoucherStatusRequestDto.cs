namespace Notification.CoreInterface.Dtos
{
    public class ByVoucherStatusRequestDto : BasicRequestDto
    {
        public string MerchantName
        {
            get;
            set;
        }
        public string ShopName
        {
            get;
            set;
        }

        public string TranCode
        {
            get;
            set;
        }
    }
}
