using XMLToolLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GetXmlNodeByXmlPathEx
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = XmlHelper.LoadXml(@"D:\Study\CollectedCSharpUsefulCode\XMLEx\Product.xml");
            XmlNode node = XmlHelper.GetXmlNodeByXmlPath(xml, "Product/shopList/Shop/ShopId");
            XmlNodeList nodeList = XmlHelper.GetXmlNodesByXmlPath(xml, "Product/shopList/Shop/ShopId");

            XmlHelper.AppendElement(node, "SubShopId");
            XmlHelper.AppendElement(node, "SubShopId", "6");//<ShopId>2<SubShopId>6</SubShopId></ShopId>
        }
    }
}
