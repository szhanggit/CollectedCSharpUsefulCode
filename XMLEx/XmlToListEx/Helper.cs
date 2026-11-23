using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlToListEx
{
    public static class Helper
    {
        public static List<T> XmlToList<T>(string xml)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<T>));
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(xml);
            MemoryStream ms = new MemoryStream(bytes);
            object o = xs.Deserialize(ms);

            ms.Close();

            return (List<T>)o;
        }

        public static string ListToXml<T>(List<T> dtoList) where T : new()
        {
            XmlSerializer xs = new XmlSerializer(dtoList.GetType());
            MemoryStream ms = new MemoryStream();

            xs.Serialize(ms, dtoList);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            string result1 = sr.ReadToEnd();
            ms.Close();

            sr.Close();
            return result1;
        }
    }
}
