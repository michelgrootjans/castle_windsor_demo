using System.Linq;
using Zork.Core.Api;
using Zork.Core.Common;

namespace Zork.Core.Characters
{
    public class CharacterInfoMapper : IMapper<Character, CharacterInfoDto>
    {
        private readonly IMapper<IChoiceInfo, PlayerChoiceDto> choiceMapper;

        public CharacterInfoMapper()
        {
            choiceMapper = new PlayerChoiceMapper();
        }

        public CharacterInfoDto Map(Character character)
        {
            if (character == null) return null;
            return new CharacterInfoDto
                       {
                           IsAlive = character.IsAlive,
                           Name = character.Name,
                           Health = character.Health,
                           MaxHealth = character.MaxHealth,
                           Gold = character.Gold,
                           TaskDescription = character.CurrentTask.Description,
                           Choices = character.CurrentTask.Choices.Select(choiceMapper.Map)
                       };
        }
    }
}