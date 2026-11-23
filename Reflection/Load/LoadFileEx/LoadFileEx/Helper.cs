using ServiceBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoadFileEx
{
    public class Helper
    {
        private object InvokeMethod(string typeFullName, string methodName, object request)
        {
            Type type = Type.GetType(typeFullName);
            MethodInfo methodInfo = type.GetMethod(methodName);
            object MeObj = Activator.CreateInstance(type);
            return methodInfo.Invoke(MeObj, new object[] { request });
        }

        public static object Invoke(string assemblyName, string fullClassName, string methodName, params Object[] args)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyName));
                Type tp = assembly.GetType(fullClassName);  //Type type = Type.GetType(typeFullName);
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

        public static void Invoke2(string assemblyName, string fullClassName, string accountName, string pwd, string url)
        {
            try
            {
                IApiService res = (IApiService)Activator.CreateInstance(assemblyName, fullClassName).Unwrap();
                res.Do(accountName, pwd, url);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw ex.InnerException;
                else
                    throw ex;
            }
        }

        public static void Invoke3(string assemblyName, string fullClassName, string method, params Object[] args)
        {
            ProxyObject obj;

            try
            {
                obj = new ProxyObject();
                obj.LoadAssembly(AppDomain.CurrentDomain.BaseDirectory + assemblyName);
                object result = obj.Invoke(fullClassName, method, args);
            }
            catch (Exception)
            {

            }
            finally
            {
                obj = null;
            }
        }

        public static void Invoke4(string assemblyName, string fullClassName, string method, string accountName, string pwd, string url)
        {
            AppDomain ad = AppDomain.CreateDomain("Proxy Domain");
            IApiService aService = (IApiService)ad.CreateInstanceFromAndUnwrap(AppDomain.CurrentDomain.BaseDirectory + assemblyName, fullClassName);
            aService.Do(accountName, pwd, url);
        }
    }
}
