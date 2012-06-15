using Zork.Core.Tasks;

namespace Zork.Core.Common
{
    public class GetInABarFightTask : ITask
    {
        public string Code
        {
            get { return "B"; }
        }

        public string Description
        {
            get { return "Go to a bar and have a drink"; }
        }
    }
}