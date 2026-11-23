using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriterEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string Content = "dfadsfadsfasdfasdfasdfasdfasdfasdfasdf";
            string FilePath = @"D:\fileEx.txt";
            FileHelper.WriteFile(FilePath, Content);
            string outputStr = FileHelper.ReadFile(FilePath);
        }
    }
}
