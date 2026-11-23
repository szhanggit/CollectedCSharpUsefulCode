using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LoadFileEx
{
    public sealed class ProxyObject : MarshalByRefObject
    {
        Assembly assembly = null;

        public void LoadAssembly(string assembleyName)
        {
            assembly = Assembly.LoadFile(assembleyName);
        }

        public object Invoke(string fullClassName, string methodName, params Object[] args)
        {
            try
            {
                Type tp = assembly.GetType(fullClassName);
                MethodInfo method = tp.GetMethod(methodName);
                Object obj = Activator.CreateInstance(tp, null);
                return method.Invoke(obj, args);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw ex.InnerException;
                else
                    throw ex;

            }
        }
    }
}
