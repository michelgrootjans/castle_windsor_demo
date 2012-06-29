using System;
using System.Threading;

namespace Zork.Core.Api.Common
{
    public class DummySessionFactory : ISessionFactory
    {
        public DummySessionFactory()
        {
            Console.WriteLine("Creating a new SessionFactory...");
            Thread.Sleep(2000);
        }

        public ISession OpenSession()
        {
            Console.WriteLine("Opening a new session...");
            return new DummySession();
        }
    }

    public class DummySession : ISession
    {
        public DummySession()
        {
            Console.WriteLine("Creating a session");
        }

        public ITransaction BeginTransaction()
        {
            Console.WriteLine("Beginning a new transaction...");
            return new DummyTransaction();
        }
    }

    public class DummyTransaction : ITransaction
    {
        public void Commit()
        {
            Console.WriteLine("Committing transaction...");
        }

        public void Rollback()
        {
            Console.WriteLine("Rolling back transaction...");
        }
    }
}