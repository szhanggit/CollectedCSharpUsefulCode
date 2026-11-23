using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPCAssemblyLoadingEx
{
    public static class ContainerBuilderExtensions
    {
        public static void ScanAssembly(this ContainerBuilder builder, string subPath, string searchPattern = "TPC.*.Operation.dll")
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subPath);
            foreach (var assembly in Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories).Select(Assembly.LoadFrom))
            {
                builder.RegisterAssemblyModules(assembly);
            }
        }
    }
}
