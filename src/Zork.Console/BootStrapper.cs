using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;

namespace Zork.ConsoleApp
{
    public class BootStrapper
    {
        private static IWindsorContainer windsorContainer;

        public static IWindsorContainer GetContainer()
        {
            return windsorContainer ?? (windsorContainer = InitializeContainer());
        }

        private static WindsorContainer InitializeContainer()
        {
            var container = new WindsorContainer();
            // Important opt-in for this behavior before registering components !
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            
            RegisterComponents(container);
            return container;
        }


        private static void RegisterComponents(IWindsorContainer container)
        {
        }
    }
}