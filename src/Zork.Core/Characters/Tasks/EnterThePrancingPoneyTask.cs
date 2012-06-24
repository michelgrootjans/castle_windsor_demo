using System;
using System.Collections.Generic;

namespace Zork.Core.Characters.Tasks
{
    public class EnterThePrancingPoneyTask : ITaskInfo, IExecutableTask
    {
        private readonly ITaskInfo originalTask;

        public EnterThePrancingPoneyTask(ITaskInfo originalTask)
        {
            this.originalTask = originalTask;
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IChoiceInfo> Choices
        {
            get { throw new NotImplementedException(); }
        }

        public void Execute(string code, ITaskHolder character)
        {
            throw new NotImplementedException();
        }
    }
}