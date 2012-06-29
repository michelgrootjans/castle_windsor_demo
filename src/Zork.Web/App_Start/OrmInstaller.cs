using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Zork.Core.Api.Common;

namespace Zork.Web.App_Start
{
    public class OrmInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ISessionFactory>()
                                   .ImplementedBy<DummySessionFactory>()
                                   .LifestyleSingleton());

            container.Register(Component.For<ISession>()
                                   .UsingFactoryMethod(c => c.Resolve<ISessionFactory>().OpenSession())
                                   .LifestylePerWebRequest());

            container.Register(Component.For<OrmTransactionInterceptor>()
                                   .LifestylePerWebRequest());
        }
    }
}