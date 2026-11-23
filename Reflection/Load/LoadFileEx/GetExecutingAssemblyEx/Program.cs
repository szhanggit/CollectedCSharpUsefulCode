using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetExecutingAssemblyEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "StarbucksSyncSchedule";
            var currentType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .SingleOrDefault(t => t.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            IScheduleExcute scheduleExcute = (IScheduleExcute)Activator.CreateInstance(currentType);
            scheduleExcute.ExcuteJob();
        }
    }
}
