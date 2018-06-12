namespace CQRS.Core.Commands
{
    public interface IHandleCommand
    {
    }

    public interface IHandleCommand<TCommand> : IHandleCommand
    where TCommand : ICommand
    {
        ICommandResult Handle(TCommand command);
    }
}
