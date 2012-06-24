using System;
using System.Collections.Generic;
using Zork.Core.Characters.Monsters;

namespace Zork.Core.Characters.Tasks
{
    public class GoUpTheMountainOfDoomTask : ITaskInfo, IExecutableTask
    {
        private readonly IMonster monster;
        private readonly IExecutableTask originalTask;
        private List<IChoiceInfo> choices;

        public GoUpTheMountainOfDoomTask(IExecutableTask originalTask)
        {
            this.originalTask = originalTask;
            monster = new GrumpyDatabaseAdministrator();
        }

        public string Description
        {
            get
            {
                var description = "You are at the top of the Mountain of Doom.";
                if (monster.IsAlive)
                    description += string.Format("A {0} is here ...", monster.Name);
                else
                    description += string.Format("A dead {0} lies on the ground.", monster.Name);
                return description;
            }
        }

        public IEnumerable<IChoiceInfo> Choices
        {
            get
            {
                if (monster.IsAlive)
                    yield return new Choice("A", "Attack the GDBA", new AttackTask(monster, this));
                yield return new Choice("B", "Go back", originalTask);
            }
        }

        public IExecutableTask Execute(string code, Character character)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMonster
    {
        string Name { get; }
        int Health { get; }
        int AttackPoints { get; }
        int DefensePoints { get; }
        void TakeHit(int hitPoints);
        bool IsAlive { get; }
        bool IsDead { get; }
    }
}