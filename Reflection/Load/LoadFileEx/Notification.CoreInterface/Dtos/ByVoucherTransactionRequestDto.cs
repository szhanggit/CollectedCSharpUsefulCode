namespace Notification.CoreInterface.Dtos
{
    public class ByVoucherTransactionRequestDto : BasicRequestDto
    {
        public string TranAmout
        {
            get;
            set;
        }
        public string BalanceAvailable
        {
            get;
            set;
        }
        public string Balance
        {
            get;
            set;
        }
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
