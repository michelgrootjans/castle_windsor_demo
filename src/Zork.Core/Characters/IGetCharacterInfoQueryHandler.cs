using System;
using System.Collections.Generic;

namespace Zork.Core.Characters
{
    public interface IGetCharacterInfoQueryHandler
    {
        CharacterInfoDto GetCharacterOf(string userName);
    }

    public class CharacterInfoDto
    {
        public bool IsAlive { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public string TaskDescription { get; set; }
        public IEnumerable<PlayerChoiceDto> Choices { get; set; }
    }

    public class PlayerChoiceDto
    {
        public string Code { get; set; }
        public string Text { get; set; }
    }
}