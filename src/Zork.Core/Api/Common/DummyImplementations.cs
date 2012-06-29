using System;
using System.Threading;

namespace Zork.Core.Api.Common
{
    public class DummySessionFactory : ISessionFactory
    {
        public DummySessionFactory()
        {
            //a SessionFactory is expensive to build
            Console.Write("Creating a new SessionFactory");
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(200); 
                Console.Write(".");                
            }
            Console.WriteLine("done.");
        }

        public ISession OpenSession()
        {
            Console.WriteLine("Opening a new session...");
            return new DummySession();
        }
    }

    public class DummySession : ISession
    {
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