namespace Zork.Core.Api
{
    public interface IUserChoiceHandler
    {
        void Execute(UserChoiceCommand command);
    }

    public class UserChoiceCommand
    {
        public string UserName { get; set; }
        public string Choice { get; set; }
    }
}