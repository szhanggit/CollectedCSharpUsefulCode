using BOL;
using System;

namespace EnumWithProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartVoucher sv = new SmartVoucher();
            bool isSmartVoucher = sv.IsSmartVoucher(MWVEmailTemplate.SmartVoucher);
        }
    }
}
