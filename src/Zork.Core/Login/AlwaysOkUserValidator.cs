namespace Zork.Core.Login
{
    public class AlwaysOkUserValidator : IUserValidator
    {
        public bool IsValid(string userName, string password)
        {
            return true;
        }
    }
}