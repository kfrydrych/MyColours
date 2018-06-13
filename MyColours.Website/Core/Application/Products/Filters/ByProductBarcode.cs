using MyColours.Website.Core.ViewModels.Products;
using System.Linq;
using MyColours.Website.Core.Common;
using AutoMapper;

namespace MyColours.Website.Core.Application.Products.Filters
{
    public class ByProductBarcode : Filter<ProductViewModel>
    {
        private readonly string _productBarcode;

        public ByProductBarcode(string productBarcode)
        {
            _productBarcode = productBarcode;
        }

        public override ProductViewModel FilterFromSource(IUnitOfWork unitOfWork)
        {
            var product = unitOfWork.Products.GetAll().SingleOrDefault(x => x.Barcode == _productBarcode);
            return Mapper.Map<ProductViewModel>(product);
        }
    }
}