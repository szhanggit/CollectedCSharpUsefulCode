using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SerializeEx
{
    public static class Helper
    {
        public static string Serialize<T>(T t)
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
