using System;
using Zork.ConsoleApp.Utilities;
using Zork.Core.Entities;
using Zork.Core.Memberships;
using Zork.Core.Tasks;

namespace Zork.ConsoleApp
{
    internal class Game
    {
        private readonly IMembershipProvider membershipProvider;
        private ITaskMenu tasks;

        public Game()
        {
            var container = BootStrapper.GetContainer();
            membershipProvider = container.Resolve<IMembershipProvider>();
            tasks = container.Resolve<ITaskMenu>();
        }

        public void Run()
        {
            PrintTitle();
            Login();
            Play();
        }

        private void PrintTitle()
        {
            Console.WriteLine("Welcome to Zork");
            Console.WriteLine("---------------");
        }

        private void Login()
        {
            var userIsValid = false;

            Console.WriteLine("Please login");
            while (!userIsValid)
            {
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Write("Password: ");
                var password = ConsolePasswordReader.ReadLine();

                userIsValid = membershipProvider.IsValidUser(username, password);

                if (!userIsValid)
                    Console.WriteLine("Unknown user, please try again...");
            }
        }

        private void Play()
        {
            var player = new Player();
            while(player.IsAlive)
            {
                Console.WriteLine("You are in an open field, west of a big white house withe a boarded front door.");
                Console.WriteLine("What do you want to do:");
                foreach (var task in tasks)
                    Console.WriteLine("{0}: {1}", task.Code, task.Description);
                Console.Write("> ");
                var taskCode = Console.ReadLine();
                player.Kill();
            }
        }
    }
}