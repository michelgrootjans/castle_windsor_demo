using Zork.Core.Characters;

namespace Zork.Core.Tasks
{
    public interface IExecutableChoice
    {
        IExecutableTask NextTask();
    }
}