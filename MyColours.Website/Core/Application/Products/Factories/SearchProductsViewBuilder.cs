using CQRS.Core.Factories;
using MyColours.Website.Core.Application.Products.Filters;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.ViewModels.Products;
using System.Collections.Generic;

namespace MyColours.Website.Core.Application.Products.Factories
{
    public class SearchProductsViewBuilder : IViewBuilder<Filter<IEnumerable<ProductViewModel>>, IEnumerable<ProductViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchProductsViewBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IEnumerable<ProductViewModel> Build(Filter<IEnumerable<ProductViewModel>> filter)
        {
            return filter.FilterFromSource(_unitOfWork);
        }
    }
}