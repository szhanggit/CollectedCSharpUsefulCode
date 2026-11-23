
namespace Notification.CoreInterface
{
    public abstract class BasicResponseDto
    {
        public virtual string returnCode { get; set; }
        public virtual string returnMessage { get; set; }
    }
}
