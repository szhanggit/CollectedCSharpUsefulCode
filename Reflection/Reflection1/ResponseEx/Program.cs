using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "A411";
            ResponseCode responseCode = new ResponseCode();
            string result = responseCode.GetType().GetField(code).GetValue(responseCode).ToString();


        }
    }
}
