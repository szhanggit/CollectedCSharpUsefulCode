using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjCompareEx
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string ProgramCode { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            Account account = obj as Account;

            if (account == null)
            {
                return false;
            }

            return AccountNumber == account.AccountNumber
                && ProgramCode == account.ProgramCode;
        }

        public override int GetHashCode()
        {
            return $"{AccountNumber}{ProgramCode}".GetHashCode();
        }
    }
}
