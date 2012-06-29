namespace Zork.ConsoleApp
{
    internal interface ICommandRouter
    {
        void Execute<T>(T command);
    }
}