using Castle.Windsor;
using Castle.Windsor.Installer;
using Zork.Web.App_Start;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof(WindsorBootstrapper), "PreStart")]
namespace Zork.Web.App_Start
{
    public static class WindsorBootstrapper
    {
        public static void PreStart()
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
        }
    }
}