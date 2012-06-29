using System;
using Zork.Core.Api.Commands;

namespace Zork.Core.Characters
{
    public class UserChoiceHandler : ICommandHandler<UserChoiceCommand>
    {
        private readonly ICharacterRepository repository;

        public UserChoiceHandler(ICharacterRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(UserChoiceCommand command)
        {
            var character = repository.GetCharacterOf(command.UserName);
            Console.WriteLine("Executing choice '{0}' for '{2} (owner: {1})'", command.Choice, command.UserName, character.Name);

            character.ExecuteChoice(command.Choice);
        }
    }
}