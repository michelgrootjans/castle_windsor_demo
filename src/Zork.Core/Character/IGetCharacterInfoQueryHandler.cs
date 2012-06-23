using System.Collections.Generic;

namespace Zork.Core
{
    public interface IGetCharacterInfoQueryHandler
    {
        CharacterInfoDto GetCharacterOf(string userName);
    }

    public class CharacterInfoDto
    {
        public bool IsAlive { get; set; }
        public string Name { get; set; }
        public string TaskDescription { get; set; }
        public IEnumerable<PlayerChoiceDto> Choices { get; set; }
    }

    public class PlayerChoiceDto
    {
        public string Code { get; set; }
        public string Text { get; set; }
    }
}