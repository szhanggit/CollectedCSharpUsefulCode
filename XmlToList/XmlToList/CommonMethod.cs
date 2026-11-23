using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

namespace XmlToList
{
    public class CommonMethod
    {
        public static List<ParamDTO> XmlToList(string xml)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<ParamDTO>));
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(xml);
            MemoryStream ms = new MemoryStream(bytes);
            object o = xs.Deserialize(ms);

            ms.Close();

            return (List<ParamDTO>)o;
        }

        public static T DeserializeFromJson<T>(string jsonString)
        {
            return Jil.JSON.Deserialize<T>(jsonString);
        }
    }
}
