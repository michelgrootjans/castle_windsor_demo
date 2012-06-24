using System;
using System.Collections.Generic;

namespace Zork.Core.Characters.Tasks
{
    public class AttackTask : ITaskInfo, IExecutableTask
    {
        public AttackTask(IMonster monster, ITaskInfo task)
        {
            throw new NotImplementedException();
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