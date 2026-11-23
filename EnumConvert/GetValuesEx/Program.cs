using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetValuesEx
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsValidated = Helper.ValidateTaskPriority(1);

            IsValidated = Enum.IsDefined(typeof(TaskPriority), (byte)50);
        }
    }
}
