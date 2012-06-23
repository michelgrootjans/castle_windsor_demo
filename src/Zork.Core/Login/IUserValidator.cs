namespace Zork.Core
{
    public interface IUserValidator
    {
        bool IsValid(string userName, string password);
    }
}