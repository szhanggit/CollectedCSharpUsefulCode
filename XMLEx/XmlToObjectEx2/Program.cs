using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToObjectEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isNull;
            string xmlFile = @"D:\MenuFormatConfig.xml";
            string xmlString = string.Empty;
            //xmlString = File.ReadAllText(xmlFile);
            List<MenuFormatViewModel> list = Helper<List<MenuFormatViewModel>>.XmlToObject(xmlString, out isNull);
        }
    }
}
