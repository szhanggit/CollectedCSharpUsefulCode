using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToObjectEx3
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuFormatViewModel mfvm = new MenuFormatViewModel {
                Name = "Product",
                Format = "___PPP___",
            };
            string smlStr = XmlSerializeHelper.Serialize<MenuFormatViewModel>(mfvm);
            MenuFormatViewModel obj = XmlSerializeHelper.Deserialize<MenuFormatViewModel>(smlStr);
        }
    }
}
