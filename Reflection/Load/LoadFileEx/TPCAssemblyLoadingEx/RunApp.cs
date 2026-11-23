using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC.Operation;

namespace TPCAssemblyLoadingEx
{
    public class RunApp : IRunApp
    {
        private IPrintMessage pm = null;
        public RunApp(IPrintMessage pm)
        {
            this.pm = pm;
        }
        public void Run(IContainer build)
        {
            int a = 2;
            int b = 1;
            string operation = "Times";
            IOperation ope = build.ResolveOptionalNamed<IOperation>(operation);
            decimal result = ope.Action(a, b);
            pm.PrintM($"{a} {operation} {b} is {result}");
        }
    }
}
