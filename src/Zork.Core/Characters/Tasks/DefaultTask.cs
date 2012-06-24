using System.Collections.Generic;

namespace Zork.Core.Characters.Tasks
{
    public class DefaultTask : Task
    {
        public override string Description
        {
            get { return "You are in your home town."; }
        }

        public override IEnumerable<IChoiceInfo> Choices
        {
            get
            {
                yield return new Choice("D", "Go to the local tavern and have a drink.", new EnterThePrancingPoneyTask(this));
                yield return new Choice("F", "Enter the dark forest.", new EnterDarkForestTask(this));
                yield return new Choice("M", "Go up the mountain of doom.", new GoUpTheMountainOfDoomTask(this));
            }
        }

        public override void Execute(string code, ITaskHolder taskHolder)
        {
            var choice = FindChoice(code);
            var newTask = choice.Execute();
            taskHolder.SetTask(newTask);
        }
    }
}