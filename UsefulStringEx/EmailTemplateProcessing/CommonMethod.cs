using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EmailTemplateProcessing
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

        public static string ListToXml(List<ParamDTO> dtoList)
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

        public static T DeserializeFromJson<T>(string jsonString)
        {
            return Jil.JSON.Deserialize<T>(jsonString);
        }

        public static string StringBefore(string text, string beforeString)
        {
            int posA = text.IndexOf(beforeString, StringComparison.InvariantCultureIgnoreCase);
            if (posA == -1)
            {
                return string.Empty;
            }
            return text.Substring(0, posA);
        }

        public static string StringBetween(string text, string firstString, string lastString)
        {
            int posA = text.IndexOf(firstString, StringComparison.InvariantCultureIgnoreCase);
            int posB = text.IndexOf(lastString, StringComparison.InvariantCultureIgnoreCase);
            if (posA == -1 || posB == -1)
            {
                return string.Empty;
            }
            int adjustedPosA = posA + firstString.Length;
            if (adjustedPosA > posB)
            {
                return string.Empty;
            }
            return text.Substring(adjustedPosA, posB - adjustedPosA);
        }

        public static string StringAfter(string text, string afterString)
        {
            int posA = text.IndexOf(afterString, StringComparison.InvariantCultureIgnoreCase);
            if (posA == -1)
            {
                return string.Empty;
            }
            int adjustedPosA = posA + afterString.Length;
            if (adjustedPosA > text.Length)
            {
                return string.Empty;
            }
            return text.Substring(adjustedPosA);
        }
    }
}
