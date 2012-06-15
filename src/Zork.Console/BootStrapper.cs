using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Zork.Core.Common;
using Zork.Core.Entities;
using Zork.Core.Memberships;
using Zork.Core.Tasks;

namespace Zork.ConsoleApp
{
    public class BootStrapper
    {
        public static IWindsorContainer GetContainer()
        {
            var container = new WindsorContainer();
            // Important opt-in for this behavior before registering components !
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            
            RegisterComponents(container);
            return container;
        }


        private static void RegisterComponents(IWindsorContainer container)
        {
            container.Register(Component
                                   .For(typeof(IFindByIdQuery<>))
                                   .ImplementedBy(typeof(FindByIdQuery<>))
                                   .LifestylePerThread());

            container.Register(Component
                                   .For<IFindUserByUsernameAndPasswordQuery>()
                                   .ImplementedBy<FindUserByUsernameAndPasswordQuery>()
                                   .LifestylePerThread());

            container.Register(Component
                                   .For<IMembershipProvider>()
                                   .ImplementedBy<DatabaseMembershipProvider>()
                                   .LifestylePerThread());

 
            // Register components
            container.Register(Classes.FromThisAssembly().BasedOn<ITask>().WithServiceAllInterfaces());
            container.Register(Component.For<ITaskMenu>().ImplementedBy<TaskMenu>());

        }

    }
}