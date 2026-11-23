using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesLib
{
    public enum TransactionEncoding
    {
        BIG5 = 2,
        UTF8 = 1,
        ASCII = 0
    }

    public static class Md5Helper
    {
        public const char Equal = '=';
        public static string Encrypt(string valueToEncrypt, string key, TransactionEncoding encoding = TransactionEncoding.ASCII)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            var md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = null;

            switch (encoding)
            {
                case TransactionEncoding.UTF8:
                    data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(Append(valueToEncrypt, Equal, key)));
                    break;
                case TransactionEncoding.BIG5:
                    data = md5Hasher.ComputeHash(Encoding.GetEncoding("Big5").GetBytes(Append(valueToEncrypt, Equal, key)));
                    break;
                case TransactionEncoding.ASCII:
                default:
                    data = md5Hasher.ComputeHash(Encoding.ASCII.GetBytes(Append(valueToEncrypt, Equal, key)));
                    break;
            }

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            if (data != null)
            {
                foreach (var item in data)
                {
                    sBuilder.Append(item.ToString("x2"));
                }
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(string input, string key, string hash, TransactionEncoding encoding = TransactionEncoding.ASCII)
        {
            // Hash the input.
            var hashOfInput = Encrypt(input, key, encoding);

            // Create a StringComparer an compare the hashes.
            return StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, hash) == 0;
        }

        private static string Append(params object[] objs)
        {
            var stringBuilder = new StringBuilder();

            foreach (var obj in objs)
            {
                stringBuilder.Append(obj);
            }

            return stringBuilder.ToString();
        }
    }
}
