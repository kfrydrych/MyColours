using AutoMapper;
using CQRS.Core.Factories;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.ViewModels.Products;

namespace MyColours.Website.Core.Application.Products.Factories
{
    public class CreditNoteFormViewBuilder : IViewBuilder<int, CreditNoteFormViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreditNoteFormViewBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public CreditNoteFormViewModel Build(int transactionId)
        {
            var transaction = _unitOfWork.Transactions
                .GetTransactionWithProducts(transactionId);

            var viewModel =  Mapper.Map<CreditNoteFormViewModel>(transaction);

            viewModel.TransactionId = transactionId;
            viewModel.CreditNoteValue = (-viewModel.InvoiceValue);

            return viewModel;
        }
    }
}