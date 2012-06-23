using System.Collections.Generic;

namespace Zork.Core
{
    public class GetCharacterInfoQueryHandler : IGetCharacterInfoQueryHandler
    {
        public CharacterInfoDto GetCharacterOf(string userName)
        {
            var playerChoiceDtos = new List<PlayerChoiceDto>
                                       {
                                           new PlayerChoiceDto {Code = "B", Text = "Go get drunk in a bar"},
                                           new PlayerChoiceDto {Code = "F", Text = "Take a walk in the dark forest"},
                                           new PlayerChoiceDto {Code = "S", Text = "Go to sleep"}
                                       };
            return new CharacterInfoDto {IsAlive = true, Name = userName, TaskDescription = "You are in a clearing.", Choices = playerChoiceDtos};
        }

    }
}