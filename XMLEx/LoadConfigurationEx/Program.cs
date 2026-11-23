using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadConfigurationEx
{
    class Program
    {
        private static NotificationProvider notificationProvider;
        static void Main(string[] args)
        {
            notificationProvider = ConfigurationCenter.LoadConfiguration();
            var dic = CommonHelper.InitAppCommandConfig();
        }
    }
}
