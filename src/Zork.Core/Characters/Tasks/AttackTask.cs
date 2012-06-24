using System;
using System.Collections.Generic;

namespace Zork.Core.Characters.Tasks
{
    public class AttackTask : ITask, IExecutableTask
    {
        public AttackTask(IMonster monster, ITask task)
        {
            throw new NotImplementedException();
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