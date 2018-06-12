using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Commands
{
    public interface ICommandResult
    {
        bool IsSuccess { get; }
        string Title { get; }
        string Message { get; }
        MessageType MessageType { get; }
        HttpStatusCode StatusCode { get; }
        IEnumerable<string> Errors { get; }
    }

    public enum MessageType
    {
        Error,
        Info,
        Success,
        Warning
    }
}
