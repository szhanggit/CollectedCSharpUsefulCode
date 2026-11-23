using BOL;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EnumWithProperty
{
    public class SmartVoucher
    {
        public bool IsSmartVoucher(MWVEmailTemplate mWVEmailTemplate)
        {
            Type t = mWVEmailTemplate.GetType();

            var memberInfo = t.GetMember(mWVEmailTemplate.ToString());
            if (memberInfo.Length > 0)
            {
                var attribute = memberInfo[0].GetCustomAttribute(typeof(SmartVoucherAttribute), false);

                if (attribute != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
