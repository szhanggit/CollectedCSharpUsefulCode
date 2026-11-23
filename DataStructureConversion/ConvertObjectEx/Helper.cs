using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConvertObjectEx
{
    public static class Helper
    {
        public static T Convert<T>(this object source) where T : new()
        {
            if (source == null)
            {
                return default(T);
            }

            T t = new T();
            Type tType = t.GetType();
            PropertyInfo property = null;

            foreach (var sourceProperty in source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                property = tType.GetProperty(sourceProperty.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (property != null && property.CanWrite)
                {
                    property.SetValue(t, sourceProperty.GetValue(source));
                }
            }

            return t;
        }
    }
}
