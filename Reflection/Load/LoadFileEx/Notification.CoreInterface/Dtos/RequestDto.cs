using System.Runtime.Serialization;

namespace Notification.CoreInterface
{
    [DataContract]
    public class RequestDto
    {
        /// <summary>
        /// Specfic the Code property is represents a client or merchant.
        /// </summary>
        [DataMember]
        public string ProviderType { get; set; }

        /// <summary>
        /// IdentityCode of client or merchant who need to be notified.
        /// </summary>
        [DataMember]
        public string ProviderCode { get; set; }

        /// <summary>
        /// The parameters which required by the client or merchant.
        /// </summary>
        [DataMember]
        public string Params { get; set; }

    }
}
