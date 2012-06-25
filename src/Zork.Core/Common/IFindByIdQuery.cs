namespace Zork.Core.Common
{
    public interface IFindByIdQuery<T> : IQuery
    {
        T FindById(int id);
    }
}