namespace zork.core.Memberships
{
    public interface IMembershipProvider
    {
        bool ValidateUser(string userName, string password);
    }
    public class AlwaysOkMembershipProvider : IMembershipProvider
    {
        public bool ValidateUser(string userName, string password)
        {
            return true;
        }
    }
}