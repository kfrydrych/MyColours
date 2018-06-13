using AutoMapper;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.ViewModels.Products;
using System.Linq;

namespace MyColours.Website.Core.Application.Products.Filters
{
    public class ByProductCode : Filter<ProductViewModel>
    {
        private readonly string _productCode;

        public ByProductCode(string code)
        {
            _productCode = code;
        }

        public override ProductViewModel FilterFromSource(IUnitOfWork unitOfWork)
        {
            var product = unitOfWork.Products.GetAll().SingleOrDefault(x => x.Code == _productCode);
            return Mapper.Map<ProductViewModel>(product);
        }
    }
}