using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjCompareEx
{
    public static class Helper
    {
        public new static bool Equals(object objA, object objB)
        {
            if (objA == null && objB == null)
            {
                return true;
            }

            if (objA == null)
            {
                return false;
            }

            if (objB == null)
            {
                return false;
            }

            return objA.Equals(objB);
        }
    }
}
