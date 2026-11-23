using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetValuesEx
{
    public enum TaskPriority : byte
    {
        High = 1,
        Normal = 2,
        Low = 3
    }

    public static class Helper
    {
        public static bool ValidateTaskPriority(int priority)
        {
            bool isValidTaskPriority = false;
            foreach (TaskPriority tp in Enum.GetValues(typeof(TaskPriority)))
            {
                if (priority == (int)tp)
                {
                    isValidTaskPriority = true;
                }
            }

            return isValidTaskPriority;
        }
    }
}
