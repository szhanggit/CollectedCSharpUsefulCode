using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DesLib
{
    public class AESHelper
    {
        public static string Encrypt(string toEncrypt, string key)
        {
            if (key.Length != 32)
            {
                throw new Exception("Not Valid a 128-bit key");
            }

            using (SymmetricAlgorithm aes = new AesCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(toEncrypt);
                aes.Key = GetBytes(key.Substring(0, 32));
                aes.IV = GetBytes(key.Substring(0, 32));

                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static string Decrypt(string toDecrypt, string key)
        {
            if (key.Length != 32)
            {
                throw new Exception("Not Valid a 128-bit key");
            }

            byte[] inputByteArray = Convert.FromBase64String(toDecrypt);
            using (SymmetricAlgorithm aes = new AesCryptoServiceProvider())
            {
                aes.Key = GetBytes(key.Substring(0, 32));
                aes.IV = GetBytes(key.Substring(0, 32));
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                }

                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        private static byte[] GetBytes(string key)
        {
            byte[] results = new byte[16];
            var array = key.ToArray();
            for (int i = 1; i < array.Length; i++)
            {
                if (i % 2 != 0)
                {
                    results[i / 2] = (byte)((byte)(byte.Parse(array[i - 1].ToString(), NumberStyles.HexNumber) << 4) | (byte.Parse(array[i].ToString(), NumberStyles.HexNumber)));
                }
            }

            return results;
        }
    }
}
