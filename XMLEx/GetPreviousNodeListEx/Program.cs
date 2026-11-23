using XMLToolLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GetPreviousNodeListEx
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = XmlHelper.LoadXml(@"D:\Study\CollectedCSharpUsefulCode\XMLEx\Product.xml");
            var list = XmlHelper.GetPreviousNodeList(xml, "Product/shopList/Shop/ShopId", "ShopFixedName");
        }
    }
}
