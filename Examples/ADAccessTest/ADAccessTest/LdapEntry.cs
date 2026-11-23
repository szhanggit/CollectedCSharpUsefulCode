using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADAccessTest
{
    [Serializable]
    public class LdapUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string DisplayName { get; set; }

        public string Telephone { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Office { get; set; }
        public string ZipCode { get; set; }
        public string Mobile { get; set; }

        public string BusinessEntity { get; set; }
        public string BusinessEntityDescription { get; set; }
        public string BusinessUnit { get; set; }
        public string BusinessUnitDescription { get; set; }
        public string ManagerUserName { get; set; }
    }
}
