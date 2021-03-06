﻿using System.Linq;
using Autofac;

namespace ShortUrl.API.AutofacModules
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register command handlers
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load($"{Startup.Namespace}.Command"))
                .Where(type => type.Name.EndsWith("CommandHandler"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}