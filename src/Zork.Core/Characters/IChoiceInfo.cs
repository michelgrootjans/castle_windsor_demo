namespace Zork.Core.Characters
{
    public interface IChoiceInfo
    {
        string Code { get; }
        string Description { get; }
        bool Matches(string code);
    }
}