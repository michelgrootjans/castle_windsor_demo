using Zork.Core.Api;

namespace Zork.Core.Characters
{
    public class CreateCharacterHandler : ICreateCharacterHandler
    {
        private readonly ICharacterRepository repository;

        public CreateCharacterHandler()
        {
            repository = new CharacterRepository();
        }

        public void Execute(CreateCharacterCommand command)
        {
            repository.Add(command.UserName, new Character(command.CharacterName));
        }
    }
}