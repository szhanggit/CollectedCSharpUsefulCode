
namespace Notification.CoreInterface
{
    public abstract class BasicRequestDto
    {
        public virtual string ProgramCode { get; set; }
        public virtual string VoucherNo { get; set; }
        public virtual byte Status { get; set; }
        public virtual string ActionDate { get; set; }
        public virtual string CheckSum { get; set; }
    }
}
