using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectService
{
    public class ObjectService
    {
        public bool IsModified { get; set; }

        public T Assign<T>(T property, T value)
        {
            if ((property != null && !property.Equals(value)) || (value != null && !value.Equals(property)))
            {
                IsModified = true;
            }

            return value;
        }
    }
}
