namespace Zork.Core.Memberships
{
    public interface IMembershipProvider
    {
        bool IsValidUser(string userName, string password);
        void RegisterNewUser(string userName, string password, string email);
        void ChangePassword(string userName, string oldPassword, string newPassword);
    }
}