using System;
using System.Collections.Generic;

namespace Zork.Core.Characters.Tasks
{
    public class GoUpTheMountainOfDoomTask : ITask, IExecutableTask
    {
        private readonly IMonster monster;
        private readonly IExecutableTask originalTask;
        private List<IChoice> choices;

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

        public IEnumerable<IChoice> Choices
        {
            get
            {
                if (monster.IsAlive)
                    yield return new Choice("A", "Attack the GDBA", new AttackTask(monster, this));
                yield return new Choice("B", "Go back", originalTask);
            }
        }

        public void Execute(string code, ITaskHolder character)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMonster
    {
        bool IsAlive { get; }
        string Name { get; }
    }

    public abstract class Monster : IMonster
    {
        protected Monster(string name)
        {
            IsAlive = true;
            Name = name;
        }

        public bool IsAlive { get; private set; }
        public string Name { get; private set; }
    }

    public class GrumpyDatabaseAdministrator : Monster
    {
        public GrumpyDatabaseAdministrator() : base("Grumpy Database Administrator")
        {
        }
    }
}