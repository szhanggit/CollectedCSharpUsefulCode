using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParkingLogApp.Lib
{
    public class CommonHelper
    {
        public static Dictionary<string, Dictionary<string, string>> InitAppCommandConfig()
        {
            var appCommandConfig = new Dictionary<string, Dictionary<string, string>>();
            var xmldoc = new XmlDocument();
            string a = AppDomain.CurrentDomain.BaseDirectory;
            string b = "CommandConfigFile".ConfigStringValue();
            xmldoc.Load(string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "CommandConfigFile".ConfigStringValue()));
            var nodes = xmldoc.SelectNodes("AppCommand/Command");
            foreach (XmlElement node in nodes)
            {
                var dic = new Dictionary<string, string>();
                dic.Add("AssemblyName", node.GetAttribute("AssemblyName"));
                dic.Add("TypeFullName", node.GetAttribute("TypeFullName"));
                appCommandConfig.Add(node.GetAttribute("Name"), dic);
            }

            return appCommandConfig;
        }        
    }
}
