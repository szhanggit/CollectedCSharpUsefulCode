using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeExample0
{
    public static class ExtensionHelper
    {
        public static bool isSmartVoucher(this MWVEmailTemplate mWVEmailTemplate)
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
