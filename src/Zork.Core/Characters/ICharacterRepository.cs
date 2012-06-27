using Zork.Core.Api.Common;

namespace Zork.Core.Characters
{
    public interface ICharacterRepository : IRepository
    {
        void Add(string userName, Character character);
        Character GetCharacterOf(string userName);
    }
}