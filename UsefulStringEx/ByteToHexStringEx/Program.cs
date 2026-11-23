using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteToHexStringEx
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://stackoverflow.com/questions/623104/byte-to-hex-string
            byte[] ba = { 1, 2, 4, 8, 16, 32 };

            string s = string.Concat(ba.Select(b => b.ToString("X2")));
            string t = string.Concat(ba.Select(b => b.ToString("X2")).ToArray());

            Console.WriteLine(s);
            Console.WriteLine(t);

            /***********************************************************************/
            //https://stackoverflow.com/questions/14057434/how-can-i-transform-string-to-utf-8-in-c
            string utf8_String = "{\"unreadMsgCount\":93,\"code\":0,\"pid\":1,\"state\":0,\"accessToken\":\"BBBBBBBBBBBBBBBBBBoy14\"}";
            byte[] bytes = Encoding.UTF8.GetBytes(utf8_String);
            foreach (byte b in bytes)
            {
                Console.Write(b + " ");
            }
            utf8_String = Encoding.UTF8.GetString(bytes);
            //utf8_String = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            Console.Write(utf8_String);

            /***********************************************************************/
            byte[] arr = { 125, 34, 52, 49, 121, 111, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 34, 58, 34, 110, 101, 107,
            111, 84, 115, 115, 101, 99, 99, 97, 34, 44, 48, 58, 34, 101, 116, 97, 116, 115, 34, 44, 49, 58, 34, 100, 105, 112, 34, 44, 48, 58, 34, 101, 100,
            111, 99, 34, 44, 51, 57, 58, 34, 116, 110, 117, 111, 67, 103, 115, 77, 100, 97, 101, 114, 110, 117, 34, 123 };
            string msg = Encoding.UTF8.GetString(arr, 0, arr.Length);


        }
    }
}
