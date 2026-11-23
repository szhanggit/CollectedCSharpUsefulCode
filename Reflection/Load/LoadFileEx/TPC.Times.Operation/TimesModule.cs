using Autofac;
using TPC.Operation;

namespace TPC.Times.Operation
{
    public class TimesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TimesOperation>().Named<IOperation>("Times");
        }
    }
}
