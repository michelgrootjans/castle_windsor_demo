using System;
using System.Threading;

namespace Zork.Core
{
    public interface IFindUserByUsernameAndPasswordQuery : IQuery
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