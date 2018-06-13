using AutoMapper;
using CQRS.Core.Factories;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.ViewModels.Products;

namespace MyColours.Website.Core.Application.Products.Factories
{
    public class TransactionDetailsViewBuilder : IViewBuilder<int,TransactionDetailsViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionDetailsViewBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public TransactionDetailsViewModel Build(int transactionId)
        {
            var transaction = _unitOfWork.Transactions
                .GetTransactionWithProducts(transactionId);

            return Mapper.Map<TransactionDetailsViewModel>(transaction);
        }
    }
}