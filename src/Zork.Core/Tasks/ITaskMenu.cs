using System;
using System.Collections;
using System.Collections.Generic;

namespace Zork.Core.Tasks
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