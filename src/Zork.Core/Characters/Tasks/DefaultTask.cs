using System;
using System.Collections.Generic;

namespace Zork.Core.Characters.Tasks
{
    public class DefaultTask : IExecutableTask
    {
        private readonly List<Choice> choices;

        public DefaultTask()
        {
            choices = new List<Choice>
                          {
                              new Choice("B", "Go to the local tavern and have a drink.", new EnterThePrancingPoneyTask(this)),
                              new Choice("F", "Enter the dark forest.", new EnterDarkForestTask(this)),
                              new Choice("F", "Go up the mountain of doom.", new GoUpTheMountainOfDoomTask(this))
                          };
        }


        public string Description
        {
            get { return "You are in your home town."; }
        }

        public IEnumerable<IChoice> Choices
        {
            get { return choices.AsReadOnly(); }
        }

        public void Execute(string code, ITaskHolder taskHolder)
        {
            var choice = FindChoice(code);
            taskHolder.SetTask(choice.Execute());
        }

        private IExecutableChoice FindChoice(string code)
        {
            return (IExecutableChoice) choices.Find(c => c.Code == code) ?? new NullChoice(this);
        }
    }

    internal interface IExecutableChoice
    {
        IExecutableTask Execute();
    }

    internal class NullChoice : IExecutableChoice
    {
        private readonly IExecutableTask task;

        public NullChoice(IExecutableTask task)
        {
            this.task = task;
        }

        public IExecutableTask Execute()
        {
            return task;
        }
    }
}