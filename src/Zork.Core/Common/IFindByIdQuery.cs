namespace Zork.Core
{
    public interface IFindByIdQuery<T> : IQuery
    {
        T FindById(int id);
    }
}