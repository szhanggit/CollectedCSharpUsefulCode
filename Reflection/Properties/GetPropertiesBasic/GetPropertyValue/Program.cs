using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPropertyValue
{
    class Program
    {
        public delegate object GetPropValueDel(object src, string propName);
        static void Main(string[] args)
        {
            Engineer _engineer = new Engineer {
                DateOfBirth = new DateTime(1981,8,7),
                FirstName = "John",
                LastName = "Black",
                Gender = 1,
                Id = 1,
                Position = "Principle",
                _accountant = new Accountant
                {
                    DateOfBirth = new DateTime(1990, 7, 3),
                    HiredDate = new DateTime(2021, 9, 12),
                    FirstName = "Peter",
                    LastName = "White",
                    Gender = 1,
                    Id = 1
                }
            };
            ICommonService _commonService = new CommonService();
            var value0 = _commonService.GetPropValue(_engineer, "LastName");
            var value1 = _commonService.GetPropValue(_engineer, "_accountant");
            var value2 = _commonService.GetPropValue(value1, "HiredDate");

            GetPropValueDel GetPropValue = (src, propName) => src.GetType().GetProperty(propName).GetValue(src, null);
            var value3 = GetPropValue(_engineer, "LastName");
            var value4 = GetPropValue(_engineer, "_accountant");
            var value5 = GetPropValue(value1, "HiredDate");
        }
    }
}
