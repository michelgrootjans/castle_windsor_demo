using System;
using Zork.Core.Common;
using Zork.Core.Entities;

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

    public class DatabaseMembershipProvider : IMembershipProvider
    {
        private readonly IRepository<User> repository;

        public DatabaseMembershipProvider(IRepository<User> repository)
        {
            this.repository = repository;
        }


        public bool IsValidUser(string userName, string password)
        {
            repository.FindById(1);
            Console.WriteLine("Yep, {0}/{1} is a valid user", userName, password);
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