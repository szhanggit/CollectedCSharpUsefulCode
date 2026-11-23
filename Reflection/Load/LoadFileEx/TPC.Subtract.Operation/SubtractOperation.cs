using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC.Operation;

namespace TPC.Subtract.Operation
{
    public class SubtractOperation : IOperation
    {
        public decimal Action(decimal A, decimal B)
        {
            decimal result = 0;
            result = A - B;
            return result;
        }
    }
}
