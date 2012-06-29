using System;
using System.Threading;
using Castle.MicroKernel;
using Zork.ConsoleApp.Utilities;
using Zork.Core.Api.Commands;
using Zork.Core.Api.Queries;

namespace Zork.ConsoleApp
{
    internal class Game
    {
        private readonly IKernel kernel;
        private string username;
        private CommandHandler commandHandler;

        public Game(IKernel kernel)
        {
            this.kernel = kernel;
            commandHandler = new CommandHandler();
        }

        public void Run()
        {
            PrintTitle();
            Login();
            do
            {
                CreatePlayer();
                while (true)
                {
                    var player = GetCharacterQuery(kernel).GetCharacterOf(username);
                    Terminal.WriteLine();
                    Terminal.WriteLine();
                    Terminal.WriteLine("*************************************************");
                    if (!player.IsAlive)
                        break;
                    PrintPlayerStatus(player);
                    Terminal.WriteLine();
                    var nextStep = GetNextStep(player);
                    if (nextStep == "quit") return;

                    GetChoiceHandler(kernel).Execute(new UserChoiceCommand {UserName = username, Choice = nextStep});
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

        private void CreatePlayer()
        {
            Terminal.WriteLine("You don't have a character. Please create one.");
            Terminal.Write("What do you want to name it: ");
            var characterName = Terminal.ReadLine();
            var command = new CreateCharacterCommand {UserName = username, CharacterName = characterName};
            GetCreateCharacterHandler(kernel).Execute(command);
            GetCharacterQuery(kernel).GetCharacterOf(username);
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

                userIsValid = GetUserValidator(kernel).IsValid(username, password);

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

        private IGetCharacterInfoQueryHandler GetCharacterQuery(IKernel k)
        {
            return k.Resolve<IGetCharacterInfoQueryHandler>();
        }

        private ICommandHandler<UserChoiceCommand> GetChoiceHandler(IKernel k)
        {
            return k.Resolve<ICommandHandler<UserChoiceCommand>>();
        }

        private ICommandHandler<CreateCharacterCommand> GetCreateCharacterHandler(IKernel k)
        {
            return k.Resolve<ICommandHandler<CreateCharacterCommand>>();
        }

        private IUserValidator GetUserValidator(IKernel k)
        {
            return k.Resolve<IUserValidator>();
        }
    }
}