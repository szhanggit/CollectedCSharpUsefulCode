using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CopyToEx
{
    public static class Helper
    {
        public static void CopyTo(this object source, object target)
        {
            if (source != null && target != null)
            {
                Type tType = target.GetType();
                PropertyInfo property = null;

                foreach (var sourceProperty in source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    property = tType.GetProperty(sourceProperty.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    if (property != null && property.CanWrite && !Equals(property.GetValue(target), sourceProperty.GetValue(source)))
                    {
                        property.SetValue(target, sourceProperty.GetValue(source));
                    }
                }
            }
        }
    }
}
