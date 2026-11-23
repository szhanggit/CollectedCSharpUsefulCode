using DesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            string Content = "Hello World!";
            string DesKey = "4F70CC34643F17B9";
            string AesKey = "B732D81A024528D800A031BB22B37BE2";
            string DesStr = DesHelper2.Encrypt(Content, DesKey, SecurityAlgorithm.DES);
            string AesStr = DesHelper2.Encrypt(Content, AesKey, SecurityAlgorithm.AES);
            string DesOri = DesHelper2.Decrypt(DesStr, DesKey, SecurityAlgorithm.DES);
            string AesOri = DesHelper2.Decrypt(AesStr, AesKey, SecurityAlgorithm.AES);
        }
    }
}
