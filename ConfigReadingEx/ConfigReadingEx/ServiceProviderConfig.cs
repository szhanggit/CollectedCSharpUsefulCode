using System.Configuration;

namespace ConfigReadingEx
{
    public class ServiceProviderConfig : ConfigurationSection
    {
        private static readonly ConfigurationProperty property = new ConfigurationProperty(string.Empty, typeof(ServiceProviderCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public ServiceProviderCollection KeyValues
        {
            get
            {
                return (ServiceProviderCollection)base[property];
            }
        }
    }
}
