using Zork.Core.Api.Common;

namespace Zork.Core.Api.Queries
{
    public interface IUserValidator : IQueryHandler
    {
        bool IsValid(string userName, string password);
    }
}