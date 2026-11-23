using StreamWriterEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToFileEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = "Hello World!";
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
            string filePath = @"D:\streamFile.txt";
            FileHelper.SaveToFile(ms, filePath);
        }
    }
}
