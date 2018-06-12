using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Commands
{
    public class CommandResult : ICommandResult
    {
        private IList<string> _errors;

        private CommandResult(bool isSuccess, string title, string message, HttpStatusCode statusCode, MessageType messageType)
        {
            IsSuccess = isSuccess;
            Message = message;
            Title = title;
            MessageType = messageType;
            StatusCode = statusCode;
            _errors = new List<string>();
        }

        private CommandResult(bool isSuccess, string title, string message, HttpStatusCode statusCode, MessageType messageType, IList<string> errors)
        {
            IsSuccess = isSuccess;
            Message = message;
            Title = title;
            MessageType = messageType;
            StatusCode = statusCode;
            _errors = errors;
        }

        public bool IsSuccess { get; }

        public string Message { get; }

        public string Title { get; }

        public MessageType MessageType { get; }

        public HttpStatusCode StatusCode { get; }

        public IEnumerable<string> Errors => _errors;

        public static CommandResult Success()
            => new CommandResult(true, "Success", "Success", HttpStatusCode.OK, MessageType.Success);

        public static CommandResult Success(string message)
            => new CommandResult(true, "Success", message, HttpStatusCode.OK, MessageType.Success);

        public static CommandResult Success(string message, HttpStatusCode statusCode)
            => new CommandResult(true, "Success", message, statusCode, MessageType.Success);

        public static CommandResult Info(string message)
            => new CommandResult(true, "Info", message, HttpStatusCode.OK, MessageType.Info);

        public static CommandResult Error()
            => new CommandResult(false, "Error", "Upss... an error has occurred while processing your request", HttpStatusCode.InternalServerError, MessageType.Error, new List<string> { "Error" });

        public static CommandResult Error(string message)
            => new CommandResult(false, "Error", message, HttpStatusCode.InternalServerError, MessageType.Error, new List<string> { "Error" });

        public static CommandResult Error(string message, HttpStatusCode statusCode)
            => new CommandResult(false, "Error", message, statusCode, MessageType.Error, new List<string> { "Error" });

        public static CommandResult Error(string message, IList<string> errors)
            => new CommandResult(false, "Error", message, HttpStatusCode.InternalServerError, MessageType.Error, errors);

        public static CommandResult Create(UnitOfWorkResult result, string successMessage)
        {
            if (result.Equals(UnitOfWorkResult.Updated))
                return Success(successMessage);

            if (result.Equals(UnitOfWorkResult.NoChanges))
                return Info("No changes been made");

            else return Error();

        }
    }
}
