using Zork.Core.Tasks;

namespace Zork.Core.Monsters
{
    public abstract class Monster : IMonster
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public int AttackPoints { get; private set; }
        public int DefensePoints { get; private set; }
        public int Gold { get; private set; }

        protected Monster(string name, int health, int attackPoints, int defensePoints, int gold)
        {
            Name = name;
            MaxHealth = health;
            Health = health;
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
            Gold = gold;
        }

        public bool IsAlive
        {
            get { return Health > 0; }
        }

        public bool IsDead
        {
            get { return !IsAlive; }
        }

        public void TakeHit(int hitPoints)
        {
            Health -= hitPoints;
        }
    }
}