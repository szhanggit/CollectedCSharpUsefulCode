using System;
using System.Configuration;

namespace ConfigReadingEx
{
    public class ServiceProviderConfigElement : ConfigurationElement
    {
        [ConfigurationProperty(CommonConsts.SERVICEPROVIDERCODE, IsRequired = true)]
        public string ServiceProviderCode
        {
            get { return this[CommonConsts.SERVICEPROVIDERCODE].ToString(); }
            set { this[CommonConsts.SERVICEPROVIDERCODE] = value; }
        }

        [ConfigurationProperty(CommonConsts.SERVICEPROVIDERNAME, IsRequired = true)]
        public string ServiceProviderName
        {
            get { return this[CommonConsts.SERVICEPROVIDERNAME].ToString(); }
            set { this[CommonConsts.SERVICEPROVIDERNAME] = value; }
        }

        [ConfigurationProperty(CommonConsts.MESSAGETYPE, IsRequired = true)]
        public MessageType MessageType
        {
            get { return (MessageType)Enum.Parse(typeof(MessageType), this[CommonConsts.MESSAGETYPE].ToString()); }
            set { this[CommonConsts.MESSAGETYPE] = value; }
        }

        [ConfigurationProperty(CommonConsts.ISDEFAULT, IsRequired = false)]
        public bool IsDefault
        {
            get { return bool.Parse(this[CommonConsts.ISDEFAULT].ToString()); }
            set { this[CommonConsts.ISDEFAULT] = value; }
        }
    }
}
