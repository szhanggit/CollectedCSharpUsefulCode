using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC.Operation
{
    public interface IOperation
    {
        decimal Action(decimal A, decimal B);
    }
}
