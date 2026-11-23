using Autofac;
using TPC.Operation;

namespace TPC.Subtract.Operation
{
    public class SubtractModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SubtractOperation>().Named<IOperation>("Subtract");
        }
    }
}
