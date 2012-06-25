using System.Collections.Generic;
using System.Linq;
using Zork.Core.Characters;

namespace Zork.Core.Tasks
{
    public abstract class Task : IExecutableTask
    {
        public abstract string Description { get; }
        public abstract IEnumerable<IChoiceInfo> Choices { get; }

        protected IExecutableChoice FindChoice(string code)
        {
            return (IExecutableChoice)Choices.FirstOrDefault(c => c.Matches(code)) ?? new NullChoice(this);
        }

        public virtual IExecutableTask Execute(string code, Character taskHolder)
        {
            var choice = FindChoice(code);
            return choice.Execute();
        }
    }

    public interface IExecutableChoice
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