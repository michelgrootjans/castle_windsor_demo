using System;
using Castle.Windsor;

namespace Zork.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                new Game().Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}