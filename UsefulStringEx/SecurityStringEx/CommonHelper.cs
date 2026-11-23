using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace SecurityStringEx
{
    public static class CommonHelper
    {
        public static string ConvertToBase36String(int n, int length)
        {
            if (n < 0)
                return null;

            var sb = new StringBuilder();

            string t = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            while (n > 0)
            {
                sb.Append(t[n % 36]);
                n /= 36;
            }

            t = sb.ToString();
            n = t.Length;
            sb.Length = 0;

            while (--n >= 0) sb.Append(t[n]);

            t = sb.ToString().PadLeft(length, '0');

            return t.Substring(0, length);
        }

        public static string MD5(string source)
        {
            using (MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider())
            {
                byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(source));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public static string HashLoginInfo(string userName, string password)
        {
            string source = userName + "=" + password;
            return MD5(source);
        }



        public static string GenerateRandomPassword(int length)
        {
            StringBuilder password = new StringBuilder();
            while (password.Length < length)
            {
                password.Append(string.Concat(System.Web.Security.Membership.GeneratePassword(1, 0).Where(char.IsLetterOrDigit)));
            }
            return password.ToString();
        }



        public static void SetKey(this object obj, string key, string value)
        {
            PropertyInfo property = obj.GetType().GetProperty(key);

            property.SetValue(obj, value);
        }

        public static object GetKey(this object obj, string key)
        {
            PropertyInfo property = obj.GetType().GetProperty(key);

            return property.GetValue(obj);
        }



        public static void SetDataRow(this DataRow dataRow, string key, object value)
        {
            if (dataRow.Table.Columns.Contains(key))
            {
                dataRow[key] = value;
            }
        }

        public static void AddEFColumn(string filePath, string tableName, params SqlParameter[] sqlParameterList)
        {
            //执行后需要运行edmx文件 生成class

            XDocument document = XDocument.Load(filePath);

            XElement element = document.Root.Elements().FirstOrDefault(e => e.Name.LocalName == "Runtime");

            foreach (var item in element.Elements())
            {
                if (item.Name.LocalName == "StorageModels")
                {
                    var ele = item.Elements().FirstOrDefault().Elements().FirstOrDefault(e => e.Name.LocalName == "EntityType" && e.FirstAttribute.Value == tableName);

                    foreach (var sqlParameter in sqlParameterList)
                    {
                        var child = new XElement((XElement)ele.LastNode);
                        child.RemoveAttributes();

                        child.Add(new XAttribute("Name", sqlParameter.ParameterName));
                        child.Add(new XAttribute("Type", sqlParameter.SqlDbType.ToString().ToLower()));
                        if (!sqlParameter.IsNullable)
                        {
                            child.Add(new XAttribute("Nullable", "false"));
                        }
                        if (sqlParameter.Size > 0)
                        {
                            child.Add(new XAttribute("MaxLength", sqlParameter.Size.ToString()));
                        }

                        ele.Add(child);
                    }
                }
                else if (item.Name.LocalName == "ConceptualModels")
                {
                    var ele = item.Elements().FirstOrDefault().Elements().FirstOrDefault(e => e.Name.LocalName == "EntityType" && e.FirstAttribute.Value == tableName);

                    foreach (var sqlParameter in sqlParameterList)
                    {
                        var child = new XElement((XElement)ele.LastNode);
                        child.RemoveAttributes();

                        child.Add(new XAttribute("Name", sqlParameter.ParameterName));
                        if (sqlParameter.DbType == DbType.AnsiString)
                        {
                            child.Add(new XAttribute("Type", DbType.String.ToString()));
                        }
                        else
                        {
                            child.Add(new XAttribute("Type", sqlParameter.DbType.ToString()));
                        }

                        if (!sqlParameter.IsNullable)
                        {
                            child.Add(new XAttribute("Nullable", "false"));
                        }
                        if (sqlParameter.Size > 0)
                        {
                            child.Add(new XAttribute("MaxLength", sqlParameter.Size.ToString()));

                            var sqlType = sqlParameter.SqlDbType.ToString().ToLower();
                            //varchar or char
                            if (sqlType.Contains("var"))
                            {
                                child.Add(new XAttribute("FixedLength", "false"));
                            }
                            else
                            {
                                child.Add(new XAttribute("FixedLength", "true"));
                            }

                            //nchar or char
                            if (sqlType.StartsWith("n"))
                            {
                                child.Add(new XAttribute("Unicode", "true"));
                            }
                            else
                            {
                                child.Add(new XAttribute("Unicode", "false"));
                            }
                        }

                        ele.Add(child);
                    }
                }
                else if (item.Name.LocalName == "Mappings")
                {
                    var ele = ((item.FirstNode as XElement).FirstNode as XElement).Elements().Where(e => e.Name.LocalName == "EntitySetMapping" && e.FirstAttribute.Value == tableName + "s").FirstOrDefault();
                    ele = ((ele.FirstNode as XElement).FirstNode as XElement);

                    foreach (var sqlParameter in sqlParameterList)
                    {
                        var child = new XElement((XElement)ele.FirstNode);
                        child.RemoveAttributes();

                        child.Add(new XAttribute("Name", sqlParameter.ParameterName));
                        child.Add(new XAttribute("ColumnName", sqlParameter.ParameterName));

                        ele.AddFirst(child);
                    }
                }
            }

            document.Save(filePath);
        }
    }
}
