using Castle.MicroKernel;
using Zork.Core.Api.Queries;

namespace Zork.ConsoleApp
{
    internal class WindsorQueryHandler : IQueryProvider
    {
        private readonly IKernel kernel;

        public WindsorQueryHandler(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public bool UserIsValid(string username, string password)
        {
            return kernel.Resolve<IUserValidator>().IsValid(username, password);
        }

        public CharacterInfoDto GetCharacterOf(string username)
        {
            return kernel.Resolve<IGetCharacterInfoQueryHandler>().GetCharacterOf(username);
        }
    }
}