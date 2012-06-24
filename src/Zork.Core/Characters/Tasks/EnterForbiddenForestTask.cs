using System.Collections.Generic;
using Zork.Core.Characters.Monsters;

namespace Zork.Core.Characters.Tasks
{
    public class EnterForbiddenForestTask : Task
    {
        private readonly IExecutableTask originalTask;
        private readonly Monster monster;

        public EnterForbiddenForestTask(IExecutableTask originalTask)
        {
            this.originalTask = originalTask;
            monster = new GrumpyDatabaseAdministrator();
        }

        public override string Description
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

        public override IEnumerable<IChoiceInfo> Choices
        {
            get
            {
                if (monster.IsAlive)
                    yield return new Choice("A", "Attack the GDBA", new AttackTask(monster, this));
                yield return new Choice("B", "Go back", originalTask);
            }
        }

    }
}