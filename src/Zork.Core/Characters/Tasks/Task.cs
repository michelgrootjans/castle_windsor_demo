using System.Collections.Generic;
using System.Linq;

namespace Zork.Core.Characters.Tasks
{
    public abstract class Task : IExecutableTask
    {
        public abstract string Description { get; }
        public abstract IEnumerable<IChoiceInfo> Choices { get; }
        public abstract void Execute(string code, ITaskHolder character);
        
        protected IExecutableChoice FindChoice(string code)
        {
            return (IExecutableChoice)Choices.FirstOrDefault(c => c.Code == code) ?? new NullChoice(this);
        }

    }

    public interface IExecutableChoice
    {
        IExecutableTask Execute();
    }

    public interface ITaskHolder
    {
        void SetTask(IExecutableTask task);
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