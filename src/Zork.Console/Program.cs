using System;
using Castle.MicroKernel;
using Zork.ConsoleApp.WindsorInstallers;

namespace Zork.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var kernel = Boot.Strap();
                new Game(new WindsorCommandRouter(kernel), new WindsorQueryHandler(kernel))
                    .Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}