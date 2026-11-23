using XMLToolLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GetNodeValueEx
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = XmlHelper.LoadXml(@"D:\Study\CollectedCSharpUsefulCode\XMLEx\Product.xml");
            XmlNode node = XmlHelper.GetXmlNodeByXmlPath(xml, "Product/shopList");
            string NodeVal = XmlHelper.GetNodeValue(node, "Shop/ShopId", string.Empty);            
        }
    }
}
