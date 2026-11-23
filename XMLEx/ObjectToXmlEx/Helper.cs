using System;
using System.IO;
using System.Xml.Serialization;

namespace ObjectToXmlEx
{
    public static class Helper<T> where T : class
    {
        public static string ObjectToXml(T t)
        {
            string result = string.Empty;
            if (t != null)
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                using (var writer = new StringWriter())
                {
                    xmlSerializer.Serialize(writer, t);
                    result = writer.ToString();
                }
            }

            return result;
        }
    }
}
