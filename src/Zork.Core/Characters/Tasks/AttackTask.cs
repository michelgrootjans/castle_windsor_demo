﻿using System.Collections.Generic;

namespace Zork.Core.Characters.Tasks
{
    public class AttackTask : Task
    {
        private readonly IMonster monster;
        private readonly IExecutableTask originalTask;

        public AttackTask(IMonster monster, IExecutableTask originalTask)
        {
            this.monster = monster;
            this.originalTask = originalTask;
        }

        public override string Description
        {
            get { return string.Format("You are in a fight with a {0}(HP: {1}).", monster.Name, monster.Health); }
        }

        public override IEnumerable<IChoiceInfo> Choices
        {
            get
            {
                yield return new Choice("A", "Continue the fight", this);
                yield return new Choice("B", "Retreat", originalTask);
            }
        }

        public override IExecutableTask Execute(string code, Character character)
        {
            character.Fight(monster);
            if (monster.IsDead) return originalTask;
            var choice = FindChoice(code);
            return choice.Execute();
        }
    }
}