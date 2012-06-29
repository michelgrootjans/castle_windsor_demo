using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Zork.Web.App_Start
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                   .BasedOn<IController>()
                                   .WithServiceAllInterfaces()
                                   .Configure(c => c.Named(c.Implementation.Name))
                                   .LifestyleTransient());
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }

    public class WindsorControllerFactory : IControllerFactory
    {
        private readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            return container.Resolve<IController>(controllerName + "Controller");
        }

        public void ReleaseController(IController controller)
        {
            container.Release(controller);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
    }
}