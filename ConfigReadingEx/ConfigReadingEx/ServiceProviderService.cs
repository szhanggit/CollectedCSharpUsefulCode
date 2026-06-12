using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConfigReadingEx
{
    public class ServiceProviderService
    {
        private static ServiceProviderConfig config = (ServiceProviderConfig)ConfigurationManager.GetSection("ServiceProviderConfig");

        public static string DefaultEmailServiceProvider
        {
            get
            {
                return config.KeyValues.Cast<ServiceProviderConfigElement>().First(e => e.IsDefault && e.MessageType == MessageType.Email).ServiceProviderCode;
            }
        }

        public static string DefaultSmsServiceProvider
        {
            get
            {
                return config.KeyValues.Cast<ServiceProviderConfigElement>().First(e => e.IsDefault && e.MessageType == MessageType.SMS).ServiceProviderCode;
            }
        }

        public static List<ServiceProvider> GetServiceProviderList(byte messageType)
        {
            return config.KeyValues.Cast<ServiceProviderConfigElement>().Where(e => e.MessageType == (MessageType)messageType).Select(e => new ServiceProvider { Code = e.ServiceProviderCode, Name = e.ServiceProviderName }).ToList();
        }

        public static string GetServiceProviderName(string serviceProviderCode, byte messageType)
        {
            var element = config.KeyValues.Cast<ServiceProviderConfigElement>().FirstOrDefault(e => e.MessageType == (MessageType)messageType && e.ServiceProviderCode == serviceProviderCode);

            return element == null ? null : element.ServiceProviderName;
        }

        public static string GetServiceProviderCode(string serviceProviderName, MessageType messageType)
        {
            var element = config.KeyValues.Cast<ServiceProviderConfigElement>().FirstOrDefault(e => e.MessageType == messageType && e.ServiceProviderName == serviceProviderName);

            return element == null ? null : element.ServiceProviderCode;
        }
    }
}
