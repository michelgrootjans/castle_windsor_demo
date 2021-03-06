﻿using System.Collections.Generic;
using Zork.Core.Characters;
using Zork.Core.Monsters;

namespace Zork.Core.Tasks
{
    public class GoUpTheMountainOfDoomTask : Task
    {
        private readonly IMonster monster;
        private readonly IExecutableTask originalTask;

        public GoUpTheMountainOfDoomTask(IExecutableTask originalTask)
        {
            this.originalTask = originalTask;
            monster = new NonCodingArchitect();
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
                    yield return new Choice("A", string.Format("Propose a simpler design to the {0}", monster.Name), new AttackTask(monster, this));
                yield return new Choice("B", "Go back", originalTask);
            }
        }
    }
}