using System.Collections.Generic;

namespace Zork.Core.Characters
{
    public interface ITask
    {
        string Description { get; }
        IEnumerable<IChoice> Choices { get; }
    }
}