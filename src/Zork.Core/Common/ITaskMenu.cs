using System;
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
        private readonly IEnumerable<ITask> tasks;

        public TaskMenu()
        {
            this.tasks = new List<ITask>
                             {
                                 new GetInABarFightTask()
                             };
        }

        public IEnumerator<ITask> GetEnumerator()
        {
            return tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}