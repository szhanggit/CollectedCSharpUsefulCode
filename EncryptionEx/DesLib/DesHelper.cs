using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DesLib
{
    public static class DesHelper
    {
        public static string Encrypt(string toEncrypt, string key)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(toEncrypt);
                des.Key = GetBytes(key.Substring(0, 16));
                des.IV = GetBytes(key.Substring(0, 16));

                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static string Decrypt(string toDecrypt, string key)
        {
            byte[] inputByteArray = Convert.FromBase64String(toDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = GetBytes(key.Substring(0, 16));
                des.IV = GetBytes(key.Substring(0, 16));
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                }

                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static byte[] GetBytes(string key)
        {
            byte[] results = new byte[8];
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
