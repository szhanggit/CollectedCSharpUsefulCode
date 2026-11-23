using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAssemblyLoadingEx
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RunApp>().As<IRunApp>();
            builder.RegisterType<PrintMessage>().As<IPrintMessage>();
            builder.ScanAssembly("Operation");

            return builder.Build();
        }
    }
}
