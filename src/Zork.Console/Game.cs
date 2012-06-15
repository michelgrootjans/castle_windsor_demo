using System;
using Zork.ConsoleApp.Utilities;
using Zork.Core.Common;
using Zork.Core.Entities;
using Zork.Core.Memberships;
using System.Linq;

namespace Zork.ConsoleApp
{
    internal class Game
    {
        private readonly IUserValidator userValidator;
        private readonly ITaskMenu tasks;

        public Game()
        {
            var container = BootStrapper.GetContainer();
            userValidator = container.Resolve<IUserValidator>();
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

                userIsValid = userValidator.IsValidUser(username, password);

                if (!userIsValid)
                    Console.WriteLine("Unknown user, please try again...");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private void Play()
        {
            do
            {
                PlayNewGame();
            } while (UserWantsToPlay());
        }

        private void PlayNewGame()
        {
            var character = new Character();
            do
            {
                PlayGameWith(character);
            } while (character.IsAlive);

            Console.WriteLine("You died...");
            Console.WriteLine();
        }

        private void PlayGameWith(Character character)
        {
            Console.WriteLine("You are in an open field, west of a big white house withe a boarded front door.");
            Console.WriteLine("What do you want to do:");
            Print(tasks);
            var task = ChooseTaskFrom(tasks);
            task.ExecuteWith(character);
        }

        private ITask ChooseTaskFrom(ITaskMenu taskMenu)
        {
            ITask task;
            do
            {
                Console.Write("> ");
                var taskCode = Console.ReadLine();
                task = taskMenu.FirstOrDefault(t => t.Code == taskCode);
            } while (task == null);
            return task;
        }

        private void Print(ITaskMenu taskMenu)
        {
            foreach (var task in taskMenu)
                Console.WriteLine(" {0}: {1}", task.Code, task.Description);
        }

        private bool UserWantsToPlay()
        {
            bool userWantsToPlay;
            Console.Write("Do you want to try again (y/n)?");
            var answer = Console.ReadLine();
            userWantsToPlay = (answer == null) ? false : answer.ToLower().StartsWith("y");
            return userWantsToPlay;
        }
    }
}