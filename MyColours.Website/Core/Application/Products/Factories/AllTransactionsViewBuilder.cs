using AutoMapper;
using CQRS.Core.Factories;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Application.Products.Factories
{
    public class AllTransactionsViewBuilder : IViewBuilder<IEnumerable<TransactionViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AllTransactionsViewBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IEnumerable<TransactionViewModel> Build()
        {
            var transactions = _unitOfWork.Transactions.GetAll();
            return Mapper.Map<IEnumerable<TransactionViewModel>>(transactions);
        }
    }
}