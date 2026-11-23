using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    public class ExpiryDateFactory
    {
        string _className = string.Empty;
        Assembly currentAssembly = Assembly.GetExecutingAssembly();

        public void getExpiryDateCalculator()
        {
            CalcService calcService = new CalcService();
            CalcService2 calcService2 = new CalcService2();
            var types = currentAssembly.GetTypes();
            foreach (var t in types)
            {
                _className = t.Name;
                //object instance = Activator.CreateInstance(t);
                ConstructorInfo constructor = t.GetConstructor(new[] { typeof(CalcService), typeof(CalcService2) });
                if (constructor != null)
                {
                    object[] constructorArguments = { calcService, calcService2 };
                    object instance = constructor.Invoke(constructorArguments);
                    MethodInfo CalcExpiryDate = t.GetMethod("CalcExpiryDate");
                    DateTime? result = (DateTime?)CalcExpiryDate.Invoke(instance, null);
                }


            }
        }
    }
}
