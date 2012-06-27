namespace Zork.Core.Api.Common
{
    public interface ISessionFactory
    {
        ISession OpenSession();
    }
}