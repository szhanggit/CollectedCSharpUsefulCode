using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public static class EnumData
    {
        public static T[] Concat<T>(this T[] x, T[] y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            int oldLen = x.Length;
            Array.Resize<T>(ref x, x.Length + y.Length);
            Array.Copy(y, 0, x, oldLen, y.Length);
            return x;
        }
    }

    public enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public enum Categories : byte
    {
        Electronics = 1,
        Food = 5,
        Automotive = 6,
        Arts = 10,
        BeautyCare = 11,
        Fashion = 15
    }

    public enum Role
    { 
        Admin,
        PM,
        Dev,
        QA,
        DevOps,
        IT,
        BA
    }

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
}
