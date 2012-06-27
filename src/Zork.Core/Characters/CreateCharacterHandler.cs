using System;
using Zork.Core.Api.Commands;

namespace Zork.Core.Characters
{
    public class CreateCharacterHandler : ICommandHandler<CreateCharacterCommand>
    {
        private readonly ICharacterRepository repository;

        public CreateCharacterHandler()
        {
            repository = new CharacterRepository();
        }

        public void Execute(CreateCharacterCommand command)
        {
            Console.WriteLine("Creating character '{0}'", command.CharacterName);
            repository.Add(command.UserName, new Character(command.CharacterName));
        }
    }
}