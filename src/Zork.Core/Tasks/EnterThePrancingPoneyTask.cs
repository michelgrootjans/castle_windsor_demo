using System.Collections.Generic;
using Zork.Core.Characters;
using Zork.Core.Characters.Tasks;
using Zork.Core.Monsters;

namespace Zork.Core.Tasks
{
    public class EnterThePrancingPoneyTask : Task
    {
        private readonly IExecutableTask originalTask;
        private readonly Monster monster;

        public EnterThePrancingPoneyTask(IExecutableTask originalTask)
        {
            this.originalTask = originalTask;
            monster = new CertifiedDotNetDeveloper();
        }

        public override string Description
        {
            get
            {
                var description = "You are in a dark, smoke filled tavern.";
                if (monster.IsAlive)
                    description += string.Format(" A {0} is here.", monster.Name);
                else
                    description += string.Format(" A dead {0} is lying on the floor.", monster.Name);
                return description;
            }
        }

        public override IEnumerable<IChoiceInfo> Choices
        {
            get
            {
                if (monster.IsAlive)
                    yield return new Choice("A", string.Format("Argue with the {0}", monster.Name), new AttackTask(monster, this));
                yield return new Choice("B", "Go back outside", originalTask);
            }
        }
    }
}