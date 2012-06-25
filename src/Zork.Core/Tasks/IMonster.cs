namespace Zork.Core.Tasks
{
    public interface IMonster
    {
        string Name { get; }
        int Gold { get; }
        int Health { get; }
        int MaxHealth { get; }
        int AttackPoints { get; }
        int DefensePoints { get; }
        void TakeHit(int hitPoints);
        bool IsAlive { get; }
        bool IsDead { get; }
    }
}