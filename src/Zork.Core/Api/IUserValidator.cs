namespace Zork.Core.Api
{
    public interface IUserValidator
    {
        bool IsValid(string userName, string password);
    }
}