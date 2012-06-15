namespace Zork.Core.Memberships
{
    public class AlwaysOkUserValidator : IUserValidator
    {
        public bool IsValidUser(string userName, string password)
        {
            return true;
        }
    }
}