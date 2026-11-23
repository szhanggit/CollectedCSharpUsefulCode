using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlToObjectEx
{
    public static class Helper<T> where T:class
    {
        public static T XmlToObject(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (var reader = new StringReader(xml))
                {
                    return xmlSerializer.Deserialize(reader) as T;
                }
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }
    }
}
