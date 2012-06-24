using System;
using Zork.Core.Characters.Tasks;

namespace Zork.Core.Characters
{
    public class Character : ITaskHolder
    {
        private IExecutableTask currentTask;

        public Character(string name)
        {
            Name = name;
            IsAlive = true;
        }

        public bool IsAlive { get; private set; }

        public string Name { get; private set; }

        public IExecutableTask CurrentTask
        {
            get { return currentTask ?? (currentTask = new DefaultTask()); }
        }

        public void ExecuteChoice(string code)
        {
            CurrentTask.Execute(code, this);
        }

        public void SetTask(IExecutableTask task)
        {
            currentTask = task;
        }
    }

    public interface IExecutableTask : ITask
    {
        void Execute(string code, ITaskHolder character);
    }

    public interface ITaskHolder
    {
        void SetTask(IExecutableTask task);
    }
}