using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    public class Days : IExpiryDateCalc
    {
        CalcService _calcService;
        CalcService2 _calcService2;
        public Days(
            CalcService calcService
            , CalcService2 calcService2)
        {
            this._calcService = calcService;
            this._calcService2 = calcService2;
        }

        public DateTime? CalcExpiryDate()
        {
            string result = _calcService.DisplayContent();
            string result2 = _calcService2.DisplayContent();
            DateTime dateTime = DateTime.Now;
            return dateTime;
        }
    }
}
