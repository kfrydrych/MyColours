using CQRS.Core.Commands;
using MyColours.Website.Core.Application.Products.Commands;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.Domain.Products;
using System;

namespace MyColours.Website.Core.Application.Products.Handlers
{
    public class ProceedIntakeFormCommandHandler : IHandleCommand<ProceedIntakeFormCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProceedIntakeFormCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICommandResult Handle(ProceedIntakeFormCommand command)
        {
            var transaction = new IntakeTransaction((DateTime)command.PurchaseDate,
                                                                      command.InvoiceNumber,
                                                                      command.InvoiceValue);

            foreach (var basketItem in command.Basket)
            {
                var product = _unitOfWork.Products.Get(basketItem.Id);
                transaction.AddToLine(product, basketItem.Quantity, basketItem.Price);
                product.UpdatePrice(basketItem.Price);
            }

            _unitOfWork.Transactions.Create(transaction);

            return CommandResult.Create(_unitOfWork.Complete(), "Transaction created");
        }
    }
}