using Zork.Core.Api.Common;
using Zork.Core.Api.Queries;

namespace Zork.Core.Characters
{
    public class PlayerChoiceMapper : IMapper<IChoiceInfo, PlayerChoiceDto>
    {
        public PlayerChoiceDto Map(IChoiceInfo choice)
        {
            return new PlayerChoiceDto { Code = choice.Code, Text = choice.Description };
        }
    }
}