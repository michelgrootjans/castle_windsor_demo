using System;

namespace Zork.Core.Login
{
    public class DatabaseUserValidator : IUserValidator
    {
        private readonly IFindUserByUsernameAndPasswordQuery userQuery;

        public DatabaseUserValidator()
        {
            userQuery = new FindUserByUsernameAndPasswordQuery();
        }

        public bool IsValid(string userName, string password)
        {
            userQuery.Find(userName, password);

            Console.WriteLine("'{0}' is a valid user", userName);
            return true;
        }
    }
}