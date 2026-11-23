using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlToObjectEx2
{
    public static class Helper<T> where T : class
    {
        public static T XmlToObject(string xml, out bool isNull)
        {
            T t = XmlToObject(xml);
            if (t == null)
            {
                isNull = true;
                t = Activator.CreateInstance(typeof(T)) as T;
            }
            else
            {
                isNull = false;
            }

            return t;
        }

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
