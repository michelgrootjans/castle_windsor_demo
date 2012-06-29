using Castle.DynamicProxy;
using Zork.Core.Api.Common;

namespace Zork.ConsoleApp.WindsorInstallers
{
    public class OrmTransactionInterceptor : IInterceptor
    {
        private readonly ISession session;

        public OrmTransactionInterceptor(ISession session)
        {
            this.session = session;
        }


        public void Intercept(IInvocation invocation)
        {
            var transaction = session.BeginTransaction();
            try
            {
                invocation.Proceed();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}