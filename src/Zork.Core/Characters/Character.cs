using System;
using Zork.Core.Characters.Tasks;

namespace Zork.Core.Characters
{
    public class Character
    {
        public string Name { get; private set; }
        public int Health { private set; get; }
        public int Gold { get; private set; }

        private int AttackPoints { get; set; }
        private int DefensePoints { get; set; }
        private IExecutableTask currentTask;
        private readonly Random rnd = new Random();

        public Character(string name)
        {
            Name = name;
            Health = 30;
            AttackPoints = 2;
            DefensePoints = 2;
            Gold = 0;
        }


        public bool IsAlive{get { return Health > 0; }}

        public ITaskInfo CurrentTask
        {
            get { return currentTask ?? (currentTask = new HomeTownTask()); }
        }

        public void ExecuteChoice(string code)
        {
            currentTask = currentTask.Execute(code, this);
        }

        public void Fight(IMonster monster)
        {
            var damageToMonster = rnd.Next(AttackPoints) - rnd.Next(monster.DefensePoints);
            if(damageToMonster > 0)
                monster.TakeHit(damageToMonster);
            if (monster.IsDead)
            {
                Gold += monster.Gold;
                return;
            }
            
            var damageToCharacter = rnd.Next(monster.AttackPoints) - rnd.Next(DefensePoints);
            if(damageToCharacter > 0)
                Health -= damageToCharacter;
        }
    }

    public interface IExecutableTask : ITaskInfo
    {
        IExecutableTask Execute(string code, Character character);
    }
}