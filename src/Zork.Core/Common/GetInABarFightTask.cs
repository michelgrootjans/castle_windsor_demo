using System;
using Zork.Core.Entities;

namespace Zork.Core.Common
{
    public class GetInABarFightTask : ITask
    {
        public string Code
        {
            get { return "B"; }
        }

        public string Description
        {
            get { return "Go to a bar and have a drink"; }
        }

        public void ExecuteWith(Character character)
        {
            Console.WriteLine("executing {0}", this.GetType());
        }
    }

    public class CommitSuicide : ITask
    {
        public string Code
        {
            get { return "S"; }
        }

        public string Description
        {
            get { return "Commit suicide"; }
        }

        public void ExecuteWith(Character character)
        {
            character.Kill();
        }
    }
}