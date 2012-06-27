namespace Zork.Core.Api.Common
{
    public interface ISession
    {
        ITransaction BeginTransaction();
    }

    public interface ITransaction
    {
        void Commit();
        void Rollback();
    }
}