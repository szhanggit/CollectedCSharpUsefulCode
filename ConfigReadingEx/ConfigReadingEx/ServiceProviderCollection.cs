using System;
using System.Configuration;

namespace ConfigReadingEx
{
    [ConfigurationCollection(typeof(ServiceProviderConfigElement))]
    public class ServiceProviderCollection : ConfigurationElementCollection
    {
        public ServiceProviderCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        new public ServiceProviderConfigElement this[string name]
        {
            get
            {
                return (ServiceProviderConfigElement)base.BaseGet(name);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceProviderConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceProviderConfigElement)element).ServiceProviderCode.ToString();
        }
    }
}
