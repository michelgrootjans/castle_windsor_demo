namespace Zork.Core.Api.Commands
{
    public interface ICommandHandler<TCommand>
    {
        void Execute(TCommand command);
    }
}