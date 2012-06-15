namespace Zork.Core.Memberships
{
    public interface IUserValidator
    {
        bool IsValidUser(string userName, string password);
    }
}