using System;
using System.Threading;
using Zork.Core.Api.Common;

namespace Zork.Core.Login
{
    public interface IFindUserByUsernameAndPasswordQuery : IDatabaseQuery
    {
        void Find(string username, string password);
    }

    public class FindUserByUsernameAndPasswordQuery : IFindUserByUsernameAndPasswordQuery
    {
        public void Find(string username, string password)
        {
            Console.Write("Looking for '{0}' in the database...", username);
            Thread.Sleep(2000);
            Console.WriteLine("there you are!");
            Thread.Sleep(500);
        }
    }
}