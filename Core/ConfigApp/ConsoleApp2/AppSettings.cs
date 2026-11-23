using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class AppSettings
    {
        public LoginCredentialsConfiguration LoginCredentials { get; set; }
        public DatabaseConfiguration DataBase { get; set; }
        public GeneralConfiguration General { get; set; }
    }
}
