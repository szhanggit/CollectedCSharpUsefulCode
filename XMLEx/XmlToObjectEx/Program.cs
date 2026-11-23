using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToObjectEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlFile = @"D:\MenuFormatConfig.xml";
            string xmlString = File.ReadAllText(xmlFile);

            Dictionary<string, MenuFormatViewModel> dictionary = new Dictionary<string, MenuFormatViewModel>();
            foreach (var menuFormatViewModel in Helper<List<MenuFormatViewModel>>.XmlToObject(xmlString))
            {
                dictionary.Add(menuFormatViewModel.Name, menuFormatViewModel);
            }
        }
    }
}
