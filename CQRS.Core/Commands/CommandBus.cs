using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Commands
{
    public class CommandsBus : ICommandsBus
    {
        private readonly Func<Type, IHandleCommand> _handlersFactory;
        public CommandsBus(Func<Type, IHandleCommand> handlersFactory)

        {
            _handlersFactory = handlersFactory;
        }

        public ICommandResult Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (IHandleCommand<TCommand>)_handlersFactory(typeof(TCommand));
            return handler.Handle(command);
        }
    }
}
