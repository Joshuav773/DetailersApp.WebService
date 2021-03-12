using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetailersApp.WebService.Bootstrap
{
    public class ServiceBootstrap : BaseBootstrapModule
    {
        protected override void RegisterAdditionalDependencies(ContainerBuilder builder)
        {
            //this is your continer wrapper, register all dependencies
        }
    }
}
