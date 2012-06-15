using System.Collections.Generic;

namespace Zork.Core.Players
{
    public interface IGetPlayerInfoQueryHandler
    {
        PlayerInfoDto HandleQuery();
    }

    public class PlayerInfoDto
    {
        public PlayerInfoDto()
        {
            Inventory = new List<ViewItemDto>();
        }

        public string Username { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public int Life { get; set; }
        public int Gold { get; set; }
        public List<ViewItemDto> Inventory { get; set; }
    }

    public class ViewItemDto
    {
        public string Name { get; set; }
    }
}