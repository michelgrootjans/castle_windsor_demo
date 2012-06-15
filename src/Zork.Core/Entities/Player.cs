namespace Zork.Core.Entities
{
    public class Player
    {
        public bool IsAlive { get; private set; }

        public Player()
        {
            IsAlive = true;
        }

        public void Kill()
        {
            IsAlive = false;
        }
    }
}