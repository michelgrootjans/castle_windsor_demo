namespace Zork.Core
{
    public interface ICreateCharacterHandler
    {
        void Execute(CreateCharacterCommand command);
    }

    public class CreateCharacterCommand
    {
        public string UserName { get; set; }
        public string CharacterName { get; set; }
    }
}