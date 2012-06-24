using System.Collections.Generic;

namespace Zork.Core.Characters.Tasks
{
    public class HomeTownTask : Task
    {
        public override string Description
        {
            get { return "You are in the home town where you grew up. You yearn for adventure, so you'd like to get out."; }
        }

        public override IEnumerable<IChoiceInfo> Choices
        {
            get
            {
                yield return new Choice("D", "Go to the the Prancing Poney and have a drink.", new EnterThePrancingPoneyTask(this));
                yield return new Choice("F", "Enter the Forbidden Forest.", new EnterForbiddenForestTask(this));
                yield return new Choice("M", "Go up the Mountain of Doom.", new GoUpTheMountainOfDoomTask(this));
            }
        }

        public override IExecutableTask Execute(string code, Character taskHolder)
        {
            var choice = FindChoice(code);
            return choice.Execute();
        }
    }
}