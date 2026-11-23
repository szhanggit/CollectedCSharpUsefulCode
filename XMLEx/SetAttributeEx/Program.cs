using XMLToolLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SetAttributeEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Study\CollectedCSharpUsefulCode\XMLEx\Product.xml";
            XmlDocument xml = XmlHelper.LoadXml(filePath);
            XmlNode node = XmlHelper.GetXmlNodeByXmlPath(xml, "Product/shopList/Shop/ShopId");
            XmlHelper.SetAttribute(node, "ShopName", "McDon");

            string AttributeVal = XmlHelper.GetAttribute(node, "ShopName", string.Empty);
            string AttributeVal1 = XmlHelper.GetAttributeFromXmlDocument(xml, "Product/shopList/Shop/ShopId", "ShopName", string.Empty);
            string AttributeVal2 = XmlHelper.GetAttributeFromXmlDocument(filePath, "Product/shopList/Shop/ShopId", "ShopFixedName", string.Empty);
        }
    }
}
