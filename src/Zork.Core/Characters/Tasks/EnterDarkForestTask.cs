using System;
using System.Collections.Generic;

namespace Zork.Core.Characters.Tasks
{
    public class EnterDarkForestTask : ITask, IExecutableTask
    {
        private readonly ITask originalTask;

        public EnterDarkForestTask(ITask originalTask)
        {
            this.originalTask = originalTask;
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IChoice> Choices
        {
            get { throw new NotImplementedException(); }
        }

        public void Execute(string code, ITaskHolder character)
        {
            throw new NotImplementedException();
        }
    }
}