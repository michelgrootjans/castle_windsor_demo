using System;
using Zork.ConsoleApp.WindsorInstallers;

namespace Zork.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                new Game(Boot.Strap())
                    .Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}