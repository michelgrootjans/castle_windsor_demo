namespace Zork.Core.Players
{
    public class GetPlayerInfoQueryHandler : IGetPlayerInfoQueryHandler
    {
        public PlayerInfoDto HandleQuery()
        {
            return new PlayerInfoDto();
        }
    }
}