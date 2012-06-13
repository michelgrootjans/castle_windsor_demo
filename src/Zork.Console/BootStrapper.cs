using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Zork.Core.Common;
using Zork.Core.Memberships;

namespace Zork.ConsoleApp
{
    public class BootStrapper
    {
        public static IWindsorContainer GetContainer()
        {
            var container = new WindsorContainer();
            RegisterComponents(container);
            return container;
        }


        private static void RegisterComponents(IWindsorContainer container)
        {
            container.Register(Component
                                   .For(typeof(IRepository<>))
                                   .ImplementedBy(typeof(Repository<>))
                                   .LifestylePerThread());

            container.Register(Component
                                   .For<IMembershipProvider>()
                                   .ImplementedBy<DatabaseMembershipProvider>()
                                   .LifestylePerThread());
        }

    }
}