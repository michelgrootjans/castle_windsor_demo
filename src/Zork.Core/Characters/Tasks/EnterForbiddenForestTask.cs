using System;
using System.Collections.Generic;

namespace Zork.Core.Characters.Tasks
{
    public class EnterForbiddenForestTask : Task
    {
        private readonly ITaskInfo originalTask;

        public EnterForbiddenForestTask(ITaskInfo originalTask)
        {
            this.originalTask = originalTask;
        }

        public override string Description
        {
            get { throw new NotImplementedException(); }
        }

        public override IEnumerable<IChoiceInfo> Choices
        {
            get { throw new NotImplementedException(); }
        }

    }
}