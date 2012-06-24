using Zork.Core.Characters.Tasks;

namespace Zork.Core.Characters
{
    public class Character : ITaskHolder
    {
        public bool IsAlive { get; private set; }
        public string Name { get; private set; }
        private IExecutableTask currentTask;

        public Character(string name)
        {
            Name = name;
            IsAlive = true;
        }

        public ITaskInfo CurrentTask
        {
            get { return currentTask ?? (currentTask = new DefaultTask()); }
        }

        public void ExecuteChoice(string code)
        {
            currentTask.Execute(code, this);
        }

        public void SetTask(IExecutableTask task)
        {
            currentTask = task;
        }
    }

    public interface IExecutableTask : ITaskInfo
    {
        void Execute(string code, ITaskHolder character);
    }
}