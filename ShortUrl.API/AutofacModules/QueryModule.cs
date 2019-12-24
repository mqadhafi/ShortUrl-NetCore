using System.Linq;
using Autofac;

namespace ShortUrl.API.AutofacModules
{
    public class QueryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register query handlers
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load($"{Startup.Namespace}.Query"))
                .Where(type => type.Name.EndsWith("QueryHandler"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}