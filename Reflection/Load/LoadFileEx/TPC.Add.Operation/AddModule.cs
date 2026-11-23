using Autofac;
using TPC.Operation;

namespace TPC.Add.Operation
{
    public class AddModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddOperation>().Named<IOperation>("Add");
        }
    }
}
