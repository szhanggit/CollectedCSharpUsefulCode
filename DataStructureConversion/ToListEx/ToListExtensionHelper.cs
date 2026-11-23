using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToListEx
{
    public static class ToListExtensionHelper
    {
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            List<T> list = null;
            if (table != null && table.Rows.Count > 0)
            {
                list = new List<T>();
                var properties = typeof(T).GetProperties();
                foreach (DataRow row in table.Rows)
                {
                    T t = new T();
                    foreach (var proerty in properties)
                    {
                        if (!table.Columns.Contains(proerty.Name))
                        {
                            continue;
                        }
                        if (proerty.CanWrite && !Convert.IsDBNull(row[proerty.Name]))
                        {
                            if (proerty.PropertyType.IsGenericType && proerty.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                proerty.SetValue(t, Convert.ChangeType(row[proerty.Name], Nullable.GetUnderlyingType(proerty.PropertyType)));
                            else
                                proerty.SetValue(t, Convert.ChangeType(row[proerty.Name], proerty.PropertyType));
                        }
                    }
                    list.Add(t);
                }
            }

            return list;
        }
    }
}
