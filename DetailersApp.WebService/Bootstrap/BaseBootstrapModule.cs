using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DetailersApp.WebService.Bootstrap
{
    public abstract class BaseBootstrapModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(a => a.Name.EndsWith("Controller") || a.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .AsSelf()
                ;

            RegisterAdditionalDependencies(builder);
            base.Load(builder);
        }

        protected abstract void RegisterAdditionalDependencies(ContainerBuilder builder);
    }
}
