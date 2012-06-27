namespace Zork.Core.Api
{
    public interface IUserValidator : IQueryHandler
    {
        bool IsValid(string userName, string password);
    }
}