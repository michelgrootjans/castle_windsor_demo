namespace Zork.Core.Memberships
{
    public class AlwaysOkMembershipProvider : IMembershipProvider
    {
        public bool IsValidUser(string userName, string password)
        {
            return true;
        }

        public void RegisterNewUser(string userName, string password, string email)
        {
        }

        public void ChangePassword(string userName, string oldPassword, string newPassword)
        {
        }
    }
}