using System;
using Zork.ConsoleApp.Utilities;
using Zork.Core;
using Zork.Core.Characters;

namespace Zork.ConsoleApp
{
    internal class Game
    {
        private readonly IGetCharacterInfoQueryHandler characterQuery;
        private readonly IUserChoiceHandler choiceHandler;
        private readonly ICreateCharacterHandler createCharacterHandler;
        private readonly IUserValidator userValidator;
        private string username;

        public Game()
        {
            characterQuery = new GetCharacterInfoQueryHandler();
            choiceHandler = new UserChoiceHandler();
            createCharacterHandler = new CreateCharacterHandler();
            userValidator = new DatabaseUserValidator();
        }

        public void Run()
        {
            PrintTitle();
            Login();
            do
            {
                var player = characterQuery.GetCharacterOf(username) ?? CreatePlayer();

                while (player.IsAlive)
                {
                    Console.Clear();
                    PrintPlayerStatus(player);
                    string nextStep = GetNextStep(player);
                    if (nextStep == "quit") return;

                    choiceHandler.Execute(new UserChoiceCommand {UserName = username, Choice = nextStep});
                    player = characterQuery.GetCharacterOf(username);
                }
                Console.WriteLine("You are dead.");
            } while (UserWantsToPlayAgain());
        }

        private void PrintPlayerStatus(CharacterInfoDto player)
        {
            Console.WriteLine("{0} is alive. Health: {1}. Gold: {2}", player.Name, player.Health, player.Gold);
        }

        private string GetNextStep(CharacterInfoDto player)
        {
            Console.WriteLine(player.TaskDescription);
            Console.WriteLine("These are your choices:");
            foreach (var choice in player.Choices)
            {
                Console.WriteLine("{0}: {1}", choice.Code, choice.Text);
            }
            Console.Write("What do you want to do: ");
            return Console.ReadLine();
        }

        private CharacterInfoDto CreatePlayer()
        {
            Console.WriteLine("You don't have a character. Please create one.");
            Console.Write("What do you want to name it: ");
            var characterName = Console.ReadLine();
            var command = new CreateCharacterCommand {UserName = username, CharacterName = characterName};
            createCharacterHandler.Execute(command);
            return characterQuery.GetCharacterOf(username);
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
                username = Console.ReadLine();
                Console.Write("Password: ");
                var password = ConsolePasswordReader.ReadLine();

                userIsValid = userValidator.IsValid(username, password);

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