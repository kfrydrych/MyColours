using CQRS.Core.Factories;
using MyColours.Website.Core.Application.Products.Filters;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.ViewModels.Products;

namespace MyColours.Website.Core.Application.Products.Factories
{
    public class ProductDetailsViewBuilder : IViewBuilder<Filter<ProductViewModel>, ProductViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductDetailsViewBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ProductViewModel Build(Filter<ProductViewModel> filter)
        {
            return filter.FilterFromSource(_unitOfWork);
        }  
    }  
}