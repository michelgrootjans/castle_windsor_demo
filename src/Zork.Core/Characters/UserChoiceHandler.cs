using Zork.Core.Api;

namespace Zork.Core.Characters
{
    public class UserChoiceHandler : IUserChoiceHandler
    {
        private readonly CharacterRepository repository;

        public UserChoiceHandler()
        {
            repository = new CharacterRepository();
        }

        public void Execute(UserChoiceCommand command)
        {
            var character = repository.GetCharacterOf(command.UserName);
            character.ExecuteChoice(command.Choice);
        }
    }
}