﻿using System;
using Zork.Core.Api.Queries;

namespace Zork.Core.Login
{
    public class DatabaseUserValidator : IUserValidator
    {
        private readonly IFindUserByUsernameAndPasswordQuery userQuery;

        public DatabaseUserValidator(IFindUserByUsernameAndPasswordQuery userQuery)
        {
            this.userQuery = userQuery;
        }

        public bool IsValid(string userName, string password)
        {
            userQuery.Find(userName, password);

            Console.WriteLine("'{0}' is a valid user {1}", userName, GetHashCode());
            return true;
        }
    }
}