using Zork.Core.Api.Common;
using Zork.Core.Api.Queries;

namespace Zork.Core.Characters
{
    public class GetCharacterInfoQueryHandler : IGetCharacterInfoQueryHandler
    {
        private readonly ICharacterRepository repository;
        private readonly IMapper<Character, CharacterInfoDto> mapper;

        public GetCharacterInfoQueryHandler(ICharacterRepository repository, IMapper<Character, CharacterInfoDto> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public CharacterInfoDto GetCharacterOf(string userName)
        {
            var character = repository.GetCharacterOf(userName);
            return mapper.Map(character);
        }

    }
}