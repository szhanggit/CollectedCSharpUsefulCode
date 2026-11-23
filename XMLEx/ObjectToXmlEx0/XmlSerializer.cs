using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ObjectToXmlEx0
{
    public class XmlSerializer
    {
        public string Serialize(object obj)
        {

            string result = string.Empty;
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
                {
                    var x = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                    x.Serialize(xmlWriter, obj);
                }
                // we just output back to the console for this demo.
                memoryStream.Position = 0; // rewind the stream before reading back.
                using (StreamReader sr = new StreamReader(memoryStream))
                {
                    result = sr.ReadToEnd();
                } // note memory stream disposed by StreamReaders Dispose()
            }
            return result;
        }


    }
}
