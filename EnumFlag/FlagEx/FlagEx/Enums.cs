using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagEx
{
    public class Enums
    {

    }

    [Flags]
    public enum ProductTag
    {
        None = 0,
        Delivery = 1,
        Paper = 2,
        Digital = 4
    }
}
