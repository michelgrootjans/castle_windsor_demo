using System;

namespace Zork.Core.Memberships
{
    public class DatabaseUserValidator : IUserValidator
    {
        private readonly IFindUserByUsernameAndPasswordQuery userQuery;

        public DatabaseUserValidator(IFindUserByUsernameAndPasswordQuery userQuery)
        {
            this.userQuery = userQuery;
        }

        public bool IsValidUser(string userName, string password)
        {
            userQuery.Find(userName, password);

            Console.WriteLine("'{0}' is a valid user", userName);
            return true;
        }
    }
}