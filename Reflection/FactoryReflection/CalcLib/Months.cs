using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    public class Months : IExpiryDateCalc
    {
        public DateTime? CalcExpiryDate()
        {
            DateTime dateTime = DateTime.Now;
            return dateTime;
        }
    }
}
