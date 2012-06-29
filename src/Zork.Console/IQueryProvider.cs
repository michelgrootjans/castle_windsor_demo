using Zork.Core.Api.Queries;

namespace Zork.ConsoleApp
{
    internal interface IQueryProvider
    {
        bool UserIsValid(string username, string password);
        CharacterInfoDto GetCharacterOf(string username);
    }
}