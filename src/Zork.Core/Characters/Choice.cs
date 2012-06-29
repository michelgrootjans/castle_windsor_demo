using Zork.Core.Tasks;

namespace Zork.Core.Characters
{
    public class Choice : IChoiceInfo, IExecutableChoice
    {
        private readonly IExecutableTask task;
        public string Code { get; private set; }
        public string Description { get; private set; }

        public Choice(string code, string description, IExecutableTask task)
        {
            this.task = task;
            Code = code;
            Description = description;
        }

        public bool Matches(string code)
        {
            return code.ToLower() == Code.ToLower();
        }

        public IExecutableTask NextTask()
        {
            return task;
        }
    }
}