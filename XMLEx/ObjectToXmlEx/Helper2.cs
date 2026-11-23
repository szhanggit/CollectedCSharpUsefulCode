using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ObjectToXmlEx
{
    public static class Helper2
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
    }
}
