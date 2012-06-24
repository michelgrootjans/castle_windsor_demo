using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;

namespace Zork.ConsoleApp
{
    public class BootStrapper
    {
        private static IWindsorContainer container;

        public static IWindsorContainer GetContainer()
        {
            return container ?? (container = InitializeContainer());
        }

        private static WindsorContainer InitializeContainer()
        {
            var windsorContainer = new WindsorContainer();
            // Important opt-in for this behavior before registering components !
            windsorContainer.Kernel.Resolver.AddSubResolver(new CollectionResolver(windsorContainer.Kernel, true));
            
            RegisterComponents(windsorContainer);
            return windsorContainer;
        }


        private static void RegisterComponents(IWindsorContainer container)
        {
        }
    }
}