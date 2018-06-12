namespace CQRS.Core.Commands
{
    public interface ICommandsBus
    {
        ICommandResult Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
