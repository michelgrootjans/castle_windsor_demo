namespace Zork.Core.Common
{
    public interface IFindByIdQuery<T>
    {
        T FindById(int id);
    }
}