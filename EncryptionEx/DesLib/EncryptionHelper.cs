using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace DesLib
{
    internal enum EncryptionAlgorithm
    {
        DES,
        TRIPLEDES
    }

    public class EncryptionHelper
    {
        private static readonly string DESKey = "9034E1F3942D8317";
        private static readonly string TripleDESKey1 = "EDENREDMWV123456EDENREDMWV123456";
        private static readonly string TripleDESKey2 = "2774EF832036A172C47C0F08E2C15D38";

        public static void Decrypt(object instance)
        {
            foreach (var property in instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite))
            {
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var list = property.GetValue(instance) as IList;
                    var paramType = property.PropertyType.GetGenericArguments()[0];

                    if (list != null)
                    {
                        foreach (var item in list)
                        {
                            foreach (var prop in paramType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite))
                            {
                                DecryptProperty(prop, item);
                            }
                        }
                    }
                }
                else
                {
                    DecryptProperty(property, instance);
                }
            }
        }

        public static void Encrypt(object instance)
        {
            foreach (var property in instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite))
            {
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var list = property.GetValue(instance) as IList;
                    var paramType = property.PropertyType.GetGenericArguments()[0];

                    if (list != null)
                    {
                        foreach (var item in list)
                        {
                            foreach (var prop in paramType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite))
                            {
                                EncryptProperty(prop, item);
                            }
                        }
                    }
                }
                else
                {
                    EncryptProperty(property, instance);
                }
            }
        }

        private static void DecryptProperty(PropertyInfo property, object instance)
        {
            var enc = property.GetCustomAttributes<EncryptedAttribute>(false).FirstOrDefault();
            if (enc != null)
            {
                var originValue = property.GetValue(instance) == null ? string.Empty : property.GetValue(instance).ToString();
                if (!string.IsNullOrEmpty(originValue))
                {
                    var decryptedValue = Decrypt(originValue, enc.EncryptionAlgorithm);
                    property.SetValue(instance, Convert.ChangeType(decryptedValue, property.PropertyType));
                }
            }
        }

        private static void EncryptProperty(PropertyInfo property, object instance)
        {
            var enc = property.GetCustomAttributes<EncryptedAttribute>(false).FirstOrDefault();
            if (enc != null)
            {
                var originValue = property.GetValue(instance) == null ? string.Empty : property.GetValue(instance).ToString();
                var encryptedValue = Encrypt(originValue, enc.EncryptionAlgorithm);
                property.SetValue(instance, Convert.ChangeType(encryptedValue, property.PropertyType));
            }
        }

        private static string Decrypt(string value, EncryptionAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case EncryptionAlgorithm.DES:
                    return DesHelper.Decrypt(value, DESKey);
                case EncryptionAlgorithm.TRIPLEDES:
                    break;
                default:
                    break;
            }
            return value;
        }

        private static string Encrypt(string value, EncryptionAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case EncryptionAlgorithm.DES:
                    return DesHelper.Encrypt(value, DESKey);
                case EncryptionAlgorithm.TRIPLEDES:
                    break;
                default:
                    break;
            }
            return value;
        }
    }
}
