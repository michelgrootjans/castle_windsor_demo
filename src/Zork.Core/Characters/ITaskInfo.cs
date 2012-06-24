using System.Collections.Generic;

namespace Zork.Core.Characters
{
    public interface ITaskInfo
    {
        string Description { get; }
        IEnumerable<IChoiceInfo> Choices { get; }
    }
}