using System;
using Zork.Core.Memberships;

namespace Zork.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = BootStrapper.GetContainer();
            var provider = container.Resolve<IMembershipProvider>();
            provider.IsValidUser("scott", "tiger");
            Console.ReadLine();
        }
    }
}