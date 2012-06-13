namespace Zork.Core.Common
{
    public interface IRepository<T>
    {
        T FindById(int id);
    }
}