namespace Zork.Core.Api.Common
{
    public interface IMapper<TFrom, TTo>
    {
        TTo Map(TFrom origin);
    }
}