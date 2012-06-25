namespace Zork.Core.Login
{
    public interface IUserValidator
    {
        bool IsValid(string userName, string password);
    }
}