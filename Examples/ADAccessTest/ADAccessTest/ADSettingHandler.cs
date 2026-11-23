using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ADAccessTest
{
    public class ADSettingHandler : IConfigurationSectionHandler
    {
        private ADSettingCollection dsc = new ADSettingCollection();

        public Object Create(object parent, object context, XmlNode node)
        {
            LoadValues(node);
            return dsc;
        }

        internal void LoadValues(XmlNode node)
        {
            XmlAttributeCollection attributeCollection = node.Attributes;
            foreach (XmlNode c in node.ChildNodes)
            {
                switch (c.Name)
                {
                    case "ADSettings":
                        LoadDataSettings(c);
                        break;
                }
            }
        }
        private void LoadDataSettings(XmlNode node)
        {
            foreach (XmlNode dsn in node.ChildNodes)
            {
                switch (dsn.Name)
                {
                    case "ADSetting":
                        bool isDefault = false;
                        if (dsn.Attributes["IsDefault"] != null)
                            isDefault = Convert.ToBoolean(dsn.Attributes["IsDefault"].Value);

                        ADSetting ds = new ADSetting(
                            dsn.Attributes["Name"].Value,
                            dsn.SelectSingleNode("ADServer").InnerText,
                            dsn.SelectSingleNode("ADUser").InnerText,
                            dsn.SelectSingleNode("ADPassword").InnerText,
                            dsn.SelectSingleNode("ADFullPath").InnerText,
                            isDefault);
                        dsc.Add(ds);
                        break;
                    case "Clear":
                        dsc.Clear();
                        break;
                }
            }
        }
    }
}
