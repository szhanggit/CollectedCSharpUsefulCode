using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoadConfigurationEx
{
    [XmlRoot("Providers")]
    public class NotificationProvider
    {
        [XmlElement("Provider")]
        public List<Provider> Providers
        {
            get;
            set;
        }
    }

    [XmlType(AnonymousType = true)]
    public class Provider
    {
        [XmlAttribute]
        public string Name
        {
            get;
            set;
        }

        [XmlAttribute]
        public string Assembly
        {
            get;
            set;
        }

        [XmlAttribute]
        public string ReflectionType
        {
            get;
            set;
        }

        [XmlAttribute]
        public string Address
        {
            get;
            set;
        }

        [XmlAttribute]
        public string SecurityKey
        {
            get;
            set;
        }

        [XmlAttribute(AttributeName = "X-LINE-ChannelId")]
        public string XLINEChannelId
        {
            get;
            set;
        }

        [XmlAttribute(AttributeName = "X-LINE-ChannelSecret")]
        public string XLINEChannelSecret
        {
            get;
            set;
        }

        [XmlAttribute]
        public string UseMockProvider
        {
            get;
            set;
        }
    }
}
