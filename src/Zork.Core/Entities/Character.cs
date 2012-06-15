namespace Zork.Core.Entities
{
    public class Character
    {
        public bool IsAlive { get; private set; }

        public Character()
        {
            IsAlive = true;
        }

        public void Kill()
        {
            IsAlive = false;
        }
    }
}