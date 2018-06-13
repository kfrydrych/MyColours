using CQRS.Core.Commands;
using MyColours.Website.Core.Application.Products.Commands;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.Domain.Products;
using System;
using System.Linq;

namespace MyColours.Website.Core.Application.Products.Handlers
{
    public class ProceedCreditNoteCommandHandler : IHandleCommand<ProceedCreditNoteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProceedCreditNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICommandResult Handle(ProceedCreditNoteCommand command)
        {
            var transaction = _unitOfWork.Transactions.Get(command.TransactionId);
            var products = _unitOfWork.Products.GetAll();
      
            var creditNoteNumber = transaction.InvoiceNumber + "/CN";
            var creditNote = new CreditNoteTransaction(DateTime.Now, creditNoteNumber, transaction.TransactionType);

            foreach (var item in command.Products)
            {
                var product = products.SingleOrDefault(x => x.Id == item.ProductId);
                transaction.RemoveFromLine(product, item.Quantity);
                creditNote.AddToLine(product, item.Quantity, product.Price);
            }

            _unitOfWork.Transactions.Create(creditNote);

            return CommandResult.Create(_unitOfWork.Complete(), "Transaction credited");
        }

    }
}