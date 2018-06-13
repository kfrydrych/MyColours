using CQRS.Core.Commands;
using MyColours.Website.Core.Application.Products.Commands;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.Domain.Products;
using System.Net;

namespace MyColours.Website.Core.Application.Products.Handlers
{
    public class DisposeProductCommandHandler : IHandleCommand<DisposeProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DisposeProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public ICommandResult Handle(DisposeProductCommand command)
        {
            var product = _unitOfWork.Products.Get(command.Id);

            if (product == null)
                return CommandResult.Error("Product not found", HttpStatusCode.NotFound);

            var transaction = new DisposalTransaction(product);

            _unitOfWork.Transactions.Create(transaction);

            return CommandResult.Create(_unitOfWork.Complete(), "Product disposed");
        }
    }
}