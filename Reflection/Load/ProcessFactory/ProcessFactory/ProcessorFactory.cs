using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessFactory
{
    public class ProcessorFactory
    {
        private static readonly List<IProcessor> IProcessorList;

        static ProcessorFactory()
        {
            IProcessorList = new List<IProcessor>(8);
            var assembly = typeof(IProcessor).Assembly;
            var list = assembly.GetExportedTypes().Where(t => (t.IsClass && !t.IsAbstract && typeof(IProcessor).IsAssignableFrom(t)));
            foreach (Type item in list)
            {
                IProcessor obj = Activator.CreateInstance(item) as IProcessor;
                IProcessorList.Add(obj);
            }
        }

        public static IProcessor Create(ESBMessageType messageType)
        {
            return IProcessorList.FirstOrDefault(p => p.CheckProcessor(messageType));
        }
    }
}
