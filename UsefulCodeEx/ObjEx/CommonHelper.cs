using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjEx
{
    /*https://stackoverflow.com/questions/5114469/how-to-check-whether-an-object-has-certain-method-property*/
    public static class CommonHelper
    {
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
    }
}
