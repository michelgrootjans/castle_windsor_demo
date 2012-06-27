namespace Zork.Core.Characters
{
    public interface ICommandHandler<TCommand>
    {
        void Execute(TCommand command);
    }
}