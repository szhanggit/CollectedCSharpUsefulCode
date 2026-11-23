using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LoadConfigurationEx
{
    public class XmlSerializeHelper
    {
        public static string Serialize<T>(T obj) where T : new()
        {
            var sb = new StringBuilder();

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;

            var serializer = new XmlSerializer(obj.GetType());
            using (var xw = XmlWriter.Create(sb, xws))
            {
                serializer.Serialize(xw, obj, ns);
                return sb.ToString();
            }
        }

        public static T Deserialize<T>(string xml) where T : new()
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var sr = new StringReader(xml))
            {
                return (T)serializer.Deserialize(sr);
            }
        }

    }
}
