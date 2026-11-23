using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"D:\Study\CSharpStudyNotes\NuGet\NPOI\Example\vc.xls";
            string path2 = @"‪D:\Study\CSharpStudyNotes\NuGet\NPOI\Example\vc.xls";

            bool b = Encoding.Equals(path1, path2);
            bool x = Helper.IsUnicode(path1);
            bool y = Helper.IsUnicode(path1);

            bool flag = Helper.StringCompareEncoding(path1, path2);
        }
    }
}
