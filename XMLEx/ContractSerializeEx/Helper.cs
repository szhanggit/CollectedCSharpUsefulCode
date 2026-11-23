using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ContractSerializeEx
{
    public static class Helper
    {
        public static string ContractSerialize<T>(T obj)
        {
            var serializer = new DataContractSerializer(obj.GetType());
            using (var ms = new MemoryStream())
            {
                using (StreamReader sr = new StreamReader(ms))
                {
                    serializer.WriteObject(ms, obj);
                    ms.Position = 0;
                    return sr.ReadToEnd();
                }
            }
        }

        /// <summary>
        ///  If using DataContractSerializer to deserialize xml, the xml should be alphabetically.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T ContractDeserialize<T>(string xml, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            var serializer = new DataContractSerializer(typeof(T));
            using (var ms = new MemoryStream(encoding.GetBytes(xml)))
            {
                return (T)serializer.ReadObject(ms);
            }
        }
    }
}
