namespace Zork.Core.Characters
{
    public interface ICharacterRepository
    {
        void Add(string userName, Character character);
        Character GetCharacterOf(string userName);
    }
}