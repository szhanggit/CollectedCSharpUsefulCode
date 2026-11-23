using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADAccessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LdapHelper _ldapHelper = new LdapHelper("ASNET");
            bool _isValid = _ldapHelper.IsUserValid("stzhang", "WelcomeDec2022");
            LdapUser _user = _ldapHelper.GetLdapUserByLogin("stzhang");
        }
    }
}
