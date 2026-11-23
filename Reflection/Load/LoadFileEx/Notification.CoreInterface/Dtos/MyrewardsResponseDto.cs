namespace Notification.CoreInterface
{
    public class MyrewardsResponseDto : BasicResponseDto
    {
        public virtual string errorCode { get; set; }
        public virtual string message { get; set; }

        public virtual string values { get; set; }
        public virtual bool success { get; set; }
    }
}
