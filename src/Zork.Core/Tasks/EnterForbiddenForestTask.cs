using System.Collections.Generic;
using Zork.Core.Characters;
using Zork.Core.Monsters;

namespace Zork.Core.Tasks
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
                var description = "You are in the gloomy Forbidden Forest.";
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
                    yield return new Choice("A", string.Format("Attack the {0}", monster.Name), new AttackTask(monster, this));
                yield return new Choice("B", "Go back", originalTask);
            }
        }

    }
}