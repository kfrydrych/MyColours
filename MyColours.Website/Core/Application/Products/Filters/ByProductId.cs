using AutoMapper;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.ViewModels.Products;

namespace MyColours.Website.Core.Application.Products.Filters
{
    public class ByProductId : Filter<ProductViewModel>
    {
        private readonly int _productId;

        public ByProductId(int id)
        {
            _productId = id;
        }

        public override ProductViewModel FilterFromSource(IUnitOfWork unitOfWork)
        {
            var product = unitOfWork.Products.Get(_productId);
            return Mapper.Map<ProductViewModel>(product);
        }
    }
}