using System.Collections;
using System.Collections.Generic;
using Zork.Core.Tasks;

namespace Zork.Core.Common
{
    public interface ITaskMenu : IEnumerable<ITask>
    {
        
    }

    public class TaskMenu : ITaskMenu
    {

        public IEnumerator<ITask> GetEnumerator()
        {
            var tasks = new List<ITask>();
            return tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}