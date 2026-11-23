using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPropertyValue
{
    public class Person
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class Engineer : Person
    {
        public string Position { get; set; }
        public Accountant _accountant { get; set; }
    }

    public class Accountant : Person
    {
        public DateTime HiredDate { get; set; }
    }
}
