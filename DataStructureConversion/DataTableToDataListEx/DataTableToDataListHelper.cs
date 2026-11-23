using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataTableToDataListEx
{
    public class DataTableToDataListHelper
    {
        public DataTableToDataListHelper()
        {

        }

        public IEnumerable<T> ConvertDataTableToList<T>(DataTable table) where T : new()
        {
            foreach (DataRow row in table.Rows)
            {
                T t = new T();
                Type tType = t.GetType();

                foreach (var property in tType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    if (table.Columns.Contains(property.Name) && !row.IsNull(property.Name))
                    {
                        property.SetValue(t, row[property.Name]);
                    }
                }

                yield return t;
            }
        }
    }
}
