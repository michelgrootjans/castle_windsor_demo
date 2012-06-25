namespace Zork.Core.Common
{
    public interface IMapper<TFrom, TTo>
    {
        TTo Map(TFrom origin);
    }
}