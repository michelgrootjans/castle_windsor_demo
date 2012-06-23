namespace Zork.Core.Characters
{
    public class CreateCharacterHandler : ICreateCharacterHandler
    {
        private CharacterRepository repository;

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