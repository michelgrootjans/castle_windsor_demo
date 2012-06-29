using Castle.MicroKernel;
using Zork.Core.Api.Commands;

namespace Zork.ConsoleApp
{
    internal class WindsorCommandRouter : ICommandRouter
    {
        private readonly IKernel kernel;

        public WindsorCommandRouter(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public void Execute<T>(T command)
        {
            var handler = kernel.Resolve<ICommandHandler<T>>();
            handler.Execute(command);
        }
    }
}