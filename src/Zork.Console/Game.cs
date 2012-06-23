using System;
using Castle.Windsor;
using Zork.ConsoleApp.Utilities;
using Zork.Core;

namespace Zork.ConsoleApp
{
    internal class Game
    {
        private string username;

        public void Run()
        {
            PrintTitle();
            Login();
            do
            {
                var player = new GetCharacterInfoQueryHandler().GetCharacterOf(username);
                while (player.IsAlive)
                {
                    Console.WriteLine(player.TaskDescription);
                    Console.WriteLine("These are your choices:");
                    foreach (var choice in player.Choices)
                    {
                        Console.WriteLine("{0}: {1}", choice.Code, choice.Text);
                    }
                    Console.Write("What do you want to do: ");
                    var answer = Console.ReadLine();
                    
                    new UserChoiceHandler().Execute(new UserChoiceCommand { Choice = answer });
                    player = new GetCharacterInfoQueryHandler().GetCharacterOf(username);
                }
                Console.WriteLine("You are dead.");
            } while (UserWantsToPlayAgain());
        }

        private void PrintTitle()
        {
            Console.WriteLine("Welcome to Zork");
            Console.WriteLine("---------------");
        }

        private void Login()
        {
            bool userIsValid = false;

            Console.WriteLine("Please login");
            while (!userIsValid)
            {
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                string password = ConsolePasswordReader.ReadLine();

                userIsValid = new DatabaseUserValidator().IsValid(username, password);

                if (!userIsValid)
                    Console.WriteLine("Unknown user, please try again...");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private bool UserWantsToPlayAgain()
        {
            Console.Write("Do you want to try again (y/n)?");
            var answer = Console.ReadLine();
            return (answer == null) ? false : answer.ToLower().StartsWith("y");
        }
    }
}