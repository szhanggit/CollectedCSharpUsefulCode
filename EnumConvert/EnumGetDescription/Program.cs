using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGetDescription
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionInfo ti = new TransactionInfo {
                AccountNumber = "asdfs",
                TranCode = "dsfadfadsfds",
                TranType = 101
            };

            EnumExtensions.ConvertCodeToMessage();
            string TranType = ((TranType)ti.TranType).ToString();
            string TranTypeName = ((TranType)ti.TranType).GetDescription();
        }
    }
}
