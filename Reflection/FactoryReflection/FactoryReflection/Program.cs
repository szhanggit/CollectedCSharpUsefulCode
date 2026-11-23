using CalcLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpiryDateFactory expiryDateFactory = new ExpiryDateFactory();
            expiryDateFactory.getExpiryDateCalculator();
        }
    }
}
