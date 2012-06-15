using System;

namespace Zork.Core.Memberships
{
    public class DatabaseMembershipProvider : IMembershipProvider
    {
        private readonly IFindUserByUsernameAndPasswordQuery userQuery;

        public DatabaseMembershipProvider(IFindUserByUsernameAndPasswordQuery userQuery)
        {
            this.userQuery = userQuery;
        }

        public bool IsValidUser(string userName, string password)
        {
            userQuery.Find(userName, password);

            Console.WriteLine("'{0}' is a valid user", userName);
            return true;
        }

        public void RegisterNewUser(string userName, string password, string email)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}