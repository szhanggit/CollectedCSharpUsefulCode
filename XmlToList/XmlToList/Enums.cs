using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToList
{
    public class Enums
    {
        public enum MWVEmailTemplate
        {
            Original = 1,
            [SmartVoucher]
            SmartVoucher = 2,
            [SmartVoucher]
            SmartVoucherWithQrCode = 3,

            [SmartVoucher]
            Order2Order = 4,

            [SmartVoucher]
            SmartVoucher_English = 5,
            [SmartVoucher]
            SmartVoucher_Japanese = 6,
            [SmartVoucher]
            SmartVoucher_Thai = 7,
            [SmartVoucher]
            SmartVoucher_Indonesian = 8,
            [SmartVoucher]
            SmartVoucher_French = 9,
            [SmartVoucher]
            SmartVoucher_JapanBento = 10,
            [SmartVoucher]
            SmartVoucher_GUIDJapanBento = 11,
            [SmartVoucher]
            SmartVoucherWithRepeater = 12
        }

        public class SmartVoucherAttribute : Attribute
        {

        }
    }
}
