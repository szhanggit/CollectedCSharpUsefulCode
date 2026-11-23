using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.Lib
{
    public class AssemblyLoadingHelper
    {
        public static object GetObj(string assemblyName, string fullClassName)
        {
            try
            {
                var res = Activator.CreateInstance(assemblyName, fullClassName).Unwrap();
                return res;
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
