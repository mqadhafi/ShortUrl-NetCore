using System.Linq;
using Autofac;

namespace ShortUrl.API.AutofacModules
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load($"{Startup.Namespace}.Business"))
                .Where(type => type.Name.EndsWith("Business"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}