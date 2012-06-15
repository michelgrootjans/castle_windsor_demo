using Zork.Core.Entities;

namespace Zork.Core.Common
{
    public interface ITask
    {
        string Code { get; }
        string Description { get; }
        void ExecuteWith(Character character);
    }
}