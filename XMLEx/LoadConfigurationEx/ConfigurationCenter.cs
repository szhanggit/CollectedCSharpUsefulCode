using System;
using System.IO;

namespace LoadConfigurationEx
{
    internal sealed class ConfigurationCenter
    {
        internal static NotificationProvider LoadConfiguration()
        {
            NotificationProvider np = null;
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GlobalConsts.ProviderConfigFile);
            var xml = File.ReadAllText(filePath);
            np = XmlSerializeHelper.Deserialize<NotificationProvider>(xml);
            return np;
        }
    }
}
