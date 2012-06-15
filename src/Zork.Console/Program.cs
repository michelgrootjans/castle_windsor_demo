using System;
using Castle.Windsor;
using Zork.ConsoleApp.Utilities;
using Zork.Core.Memberships;

namespace Zork.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new Game();
            game.Run();
            Console.ReadLine();
        }
    }

    internal class Game
    {
        private readonly IWindsorContainer container;

        public Game()
        {
            container = BootStrapper.GetContainer();
        }

        public void Run()
        {
            PrintTitle();
            Login();
        }

        private void PrintTitle()
        {
            Console.WriteLine("Welcome to Zork");
            Console.WriteLine("---------------");
        }

        private void Login()
        {
            Console.WriteLine("Please login");
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = ConsolePasswordReader.ReadLine();

            var provider = container.Resolve<IMembershipProvider>();
            provider.IsValidUser(username, password);
        }

    }
}