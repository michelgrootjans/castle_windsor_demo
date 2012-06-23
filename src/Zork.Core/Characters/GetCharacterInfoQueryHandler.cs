using System.Linq;

namespace Zork.Core.Characters
{
    public class GetCharacterInfoQueryHandler : IGetCharacterInfoQueryHandler
    {
        private readonly ICharacterRepository repository;

        public GetCharacterInfoQueryHandler()
        {
            repository = new CharacterRepository();
        }


        public CharacterInfoDto GetCharacterOf(string userName)
        {
            var character = repository.GetCharacterOf(userName);
            return Map(character);
        }

        private CharacterInfoDto Map(Character character)
        {
            if (character == null) return null;

            return new CharacterInfoDto
                       {
                           IsAlive = character.IsAlive,
                           Name = character.Name,
                           TaskDescription = character.CurrentTask.Description,
                           Choices = character.CurrentTask.Choices.Select(Map)
                       };
        }

        private PlayerChoiceDto Map(IChoice choice)
        {
            return new PlayerChoiceDto{Code = choice.Code, Text = choice.Description};
        }
    }


    public class Choice : IChoice
    {
        public string Code { get; private set; }
        public string Description { get; private set; }

        public Choice(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }

}