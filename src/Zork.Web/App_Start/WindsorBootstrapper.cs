using Zork.Web.App_Start;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof(WindsorBootstrapper), "PreStart")]
namespace Zork.Web.App_Start
{
    public static class WindsorBootstrapper
    {
        public static void PreStart()
        {
        }
    }
}