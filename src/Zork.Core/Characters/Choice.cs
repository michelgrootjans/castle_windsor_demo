using Zork.Core.Characters.Tasks;

namespace Zork.Core.Characters
{
    public class Choice : IChoice, IExecutableChoice
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

        public IExecutableTask Execute()
        {
            return task;
        }
    }
}