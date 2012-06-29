﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Zork.Core.Api.Commands;
using Zork.Core.Api.Queries;

namespace Zork.Web.App_Start
{
    public class ZorkHandlerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<IQueryHandler>()
                                   .BasedOn<IQueryHandler>()
                                   .WithServiceAllInterfaces()
                                   .LifestyleTransient());


            container.Register(Classes.FromAssemblyContaining<IQueryHandler>()
                                   .BasedOn(typeof(ICommandHandler<>))
                                   .WithServiceAllInterfaces()
                                   .Configure(c => c.Interceptors<OrmTransactionInterceptor>())
                                   .LifestyleTransient()
                );
        }
    }
}