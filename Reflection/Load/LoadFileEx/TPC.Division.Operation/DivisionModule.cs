using Autofac;
using TPC.Operation;

namespace TPC.Division.Operation
{
    public class DivisionModule : Module
    {        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DivisionOperation>().Named<IOperation>("Division");
        }
    }
}
