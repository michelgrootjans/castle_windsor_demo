using System;
using System.Collections.Generic;

namespace Zork.Core.Characters
{
    public class Character
    {
        private ITask currentTask;
        private bool isAlive;

        public Character(string name)
        {
            Name = name;
            isAlive = true;
        }

        public bool IsAlive
        {
            get { return isAlive; }
        }

        public string Name { get; private set; }

        public ITask CurrentTask
        {
            get { return currentTask ?? (currentTask = new DefaultTask()); }
        }
    }

    public interface IChoice
    {
        string Code { get; }
        string Description { get; }
    }

    public interface ITask
    {
        string Description { get; }
        IEnumerable<IChoice> Choices { get; }
    }

    public class DefaultTask : ITask
    {
        public string Description
        {
            get { return "You are in your home town."; }
        }

        public IEnumerable<IChoice> Choices
        {
            get { yield return new Choice("B", "Go to the local tavern and have a drink."); }
        }
    }
}