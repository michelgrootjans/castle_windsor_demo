using Castle.MicroKernel;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Zork.ConsoleApp.WindsorInstallers
{
    public static class Boot
    {
        public static IKernel Strap()
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
            return container.Kernel;
        }
    }
}