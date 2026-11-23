using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DesLib
{
    public enum SecurityAlgorithm
    {
        DES = 1,
        AES = 2
    }

    public static class DesHelper2
    {
        public static string Encrypt(string toEncrypt, string key, SecurityAlgorithm securityAlgorithm = SecurityAlgorithm.DES)
        {
            using (SymmetricAlgorithm des = GetCryptoServiceProvider(securityAlgorithm))
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(toEncrypt);
                des.Key = GetBytes(GetCryptoKeyString(key, securityAlgorithm), securityAlgorithm);
                des.IV = GetBytes(GetCryptoKeyString(key, securityAlgorithm), securityAlgorithm);

                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static string Decrypt(string toDecrypt, string key, SecurityAlgorithm securityAlgorithm = SecurityAlgorithm.DES)
        {
            byte[] inputByteArray = Convert.FromBase64String(toDecrypt);
            using (SymmetricAlgorithm des = GetCryptoServiceProvider(securityAlgorithm))
            {
                des.Key = GetBytes(GetCryptoKeyString(key, securityAlgorithm), securityAlgorithm);
                des.IV = GetBytes(GetCryptoKeyString(key, securityAlgorithm), securityAlgorithm);
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                }

                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        private static SymmetricAlgorithm GetCryptoServiceProvider(SecurityAlgorithm securityAlgorithm)
        {
            SymmetricAlgorithm ret = null;
            switch (securityAlgorithm)
            {
                case SecurityAlgorithm.AES:
                    ret = new AesCryptoServiceProvider();
                    break;
                case SecurityAlgorithm.DES:
                    ret = new DESCryptoServiceProvider();
                    break;
                default:
                    ret = new DESCryptoServiceProvider();
                    break;
            }

            return ret;
        }

        private static string GetCryptoKeyString(string key, SecurityAlgorithm securityAlgorithm)
        {
            var ret = key;
            switch (securityAlgorithm)
            {
                case SecurityAlgorithm.AES:
                    ret = key.Substring(0, 32);
                    break;
                case SecurityAlgorithm.DES:
                    ret = key.Substring(0, 16);
                    break;
                default:
                    ret = key.Substring(0, 16);
                    break;
            }

            return ret;
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

        public static byte[] GetBytes(string key, SecurityAlgorithm securityAlgorithm)
        {
            byte[] results = new byte[8];
            if (securityAlgorithm == SecurityAlgorithm.AES)
            {
                results = new byte[16];
            }
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
