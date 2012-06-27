using System;
using System.Threading;
using Zork.ConsoleApp.Utilities;
using Zork.Core.Api;
using Zork.Core.Api.Commands;
using Zork.Core.Api.Queries;
using Zork.Core.Characters;
using Zork.Core.Login;

namespace Zork.ConsoleApp
{
    internal class Game
    {
        private readonly IGetCharacterInfoQueryHandler characterQuery;
        private readonly ICommandHandler<UserChoiceCommand> choiceHandler;
        private readonly ICommandHandler<CreateCharacterCommand> createCharacterHandler;
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

                while (true)
                {
                    var player = characterQuery.GetCharacterOf(username) ?? CreatePlayer();
                    Terminal.WriteLine();
                    Terminal.WriteLine();
                    Terminal.WriteLine("*************************************************");
                    if (!player.IsAlive)
                        break;
                    PrintPlayerStatus(player);
                    Terminal.WriteLine();
                    var nextStep = GetNextStep(player);
                    if (nextStep == "quit") return;

                    choiceHandler.Execute(new UserChoiceCommand {UserName = username, Choice = nextStep});
                }
                Terminal.WriteLine("You are dead.");
            } while (UserWantsToPlayAgain());
        }

        private void PrintPlayerStatus(CharacterInfoDto player)
        {
            Terminal.WriteLine("{0} is alive. Health: {1}/{2}. Gold: {3}",
                               player.Name, player.Health, player.MaxHealth, player.Gold);
        }

        private string GetNextStep(CharacterInfoDto player)
        {
            using (new TerminalColor(ConsoleColor.Cyan))
                Terminal.WriteLine(player.TaskDescription);
            Terminal.WriteLine();

            Terminal.WriteLine("These are your choices:");
            foreach (var choice in player.Choices)
            {
                using (new TerminalColor(ConsoleColor.Yellow))
                    Terminal.WriteLine("{0}: {1}", choice.Code, choice.Text);
            }
            Terminal.WriteLine();
            Terminal.Write("What do you want to do: ");
            return Terminal.ReadLine();
        }

        private CharacterInfoDto CreatePlayer()
        {
            Terminal.WriteLine("You don't have a character. Please create one.");
            Terminal.Write("What do you want to name it: ");
            var characterName = Terminal.ReadLine();
            var command = new CreateCharacterCommand {UserName = username, CharacterName = characterName};
            createCharacterHandler.Execute(command);
            return characterQuery.GetCharacterOf(username);
        }

        private void PrintTitle()
        {
            using (new TerminalColor(ConsoleColor.Yellow))
            {
                Terminal.WriteLine("Welcome to Zork");
                Terminal.WriteLine("---------------");
            }
            Thread.Sleep(3000);
        }

        private void Login()
        {
            var userIsValid = false;

            Terminal.WriteLine("Please login");
            while (!userIsValid)
            {
                Terminal.Write("Username: ");
                username = Terminal.ReadLine();
                Terminal.Write("Password: ");
                var password = Terminal.ReadPassword();

                userIsValid = userValidator.IsValid(username, password);

                if (!userIsValid)
                    Terminal.WriteLine("Unknown user, please try again...");
            }
            Terminal.WriteLine();
            Terminal.WriteLine();
        }

        private bool UserWantsToPlayAgain()
        {
            Terminal.Write("Do you want to try again (y/n)?");
            var answer = Terminal.ReadLine();
            return (answer == null) ? false : answer.ToLower().StartsWith("y");
        }
    }
}