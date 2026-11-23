using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyStreamEx
{
    /*
     https://stackoverflow.com/questions/230128/how-do-i-copy-the-contents-of-one-stream-to-another
     https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.read?view=netframework-4.8	(Read)
     https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.write?view=netframework-4.8	(Write)
     https://www.cnblogs.com/kingBook/p/5970271.html
     C#用Zlib压缩或解压缩字节数组
         */
    class Program
    {
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
