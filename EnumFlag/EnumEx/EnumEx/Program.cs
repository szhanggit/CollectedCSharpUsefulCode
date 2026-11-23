using BOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumEx
{
    /*
     https://www.tutorialsteacher.com/csharp/csharp-enum
         */
    class Program
    {
        static void Main(string[] args)
        {
            string Date = Enum.GetValues(typeof(DayOfWeek)).GetValue(2).ToString();//From int to string
            Role selected = (Role)Enum.Parse(typeof(Role), "Admin");//From string to Enum item.
            //Enum.TryParse<TransactionEncoding>(transactionRequestIn.Encoding.ToUpperInvariant(), out transactionEncoding);

            var list = Enum.GetValues(typeof(MWVEmailTemplate)).Cast<MWVEmailTemplate>().ToList();//Convert Enum to list.

            string[] RoleArr = new string[] { };
            RoleArr = new[]{"All"}.Concat(Enum.GetNames(typeof(Role)));//Dynamically expand Enum.


            List<Role> role = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();//Convert Enum to list.


            Console.WriteLine(DayOfWeek.Friday); //output: Friday 
            int day = (int)DayOfWeek.Friday; // enum to int conversion
            Console.WriteLine(day); //output: 4 

            var wd = (DayOfWeek)5; // int to enum conversion
            Console.WriteLine(wd);//output: Saturday 
        }
    }
}
