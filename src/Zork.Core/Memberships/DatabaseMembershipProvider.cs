using System;
using Zork.Core.Common;
using Zork.Core.Entities;

namespace Zork.Core.Memberships
{
    public class DatabaseMembershipProvider : IMembershipProvider
    {
        private readonly IFindByIdQuery<User> userQuery;

        public DatabaseMembershipProvider(IFindByIdQuery<User> userQuery)
        {
            this.userQuery = userQuery;
        }


        public bool IsValidUser(string userName, string password)
        {
            userQuery.FindById(1);

            Console.WriteLine("Yep, '{0}'/'{1}' is a valid user", userName, password);
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