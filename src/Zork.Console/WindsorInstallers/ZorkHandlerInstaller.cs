using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Zork.Core.Api.Commands;
using Zork.Core.Api.Common;
using Zork.Core.Api.Queries;

namespace Zork.ConsoleApp.WindsorInstallers
{
    public class ZorkHandlerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var fromZorkCore = Classes.FromAssemblyContaining<IQueryHandler>();

            container.Register(fromZorkCore
                                   .BasedOn<IQueryHandler>()
                                   .WithServiceAllInterfaces()
                                   .LifestyleTransient());

            container.Register(fromZorkCore
                                   .BasedOn(typeof (ICommandHandler<>))
                                   .WithServiceAllInterfaces()
                                   .Configure(c => c.Interceptors<OrmTransactionInterceptor>())
                                   .LifestyleTransient());

            container.Register(fromZorkCore
                                   .BasedOn<IDatabaseQuery>()
                                   .WithServiceAllInterfaces()
                                   .LifestyleTransient()
                );

            container.Register(fromZorkCore
                                   .BasedOn<IRepository>()
                                   .WithServiceAllInterfaces()
                                   .LifestyleTransient());

            container.Register(fromZorkCore
                                   .BasedOn(typeof (IMapper<,>))
                                   .WithServiceAllInterfaces()
                                   .LifestyleTransient());

        }
    }
}