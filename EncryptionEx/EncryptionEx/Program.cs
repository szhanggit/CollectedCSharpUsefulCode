using DesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "1CB4A1CB219C09A4";
            string content = "Hello World!";
            string EncryptedString = DesHelper.Encrypt(content, key);
            string ori = DesHelper.Decrypt(EncryptedString, key);
        }
    }
}
