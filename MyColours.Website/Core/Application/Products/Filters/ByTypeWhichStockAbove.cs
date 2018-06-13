using AutoMapper;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.Domain.Products;
using MyColours.Website.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Application.Products.Filters
{
    public class ByTypeWhichStockAbove : Filter<IEnumerable<ProductViewModel>>
    {
        private ProductType _productType;
        private int _stockAbove;

        public ByTypeWhichStockAbove(ProductType productType, int stockAbove)
        {
            _productType = productType;
            _stockAbove = stockAbove;
        }

        public override IEnumerable<ProductViewModel> FilterFromSource(IUnitOfWork unitOfWork)
        {
            var products = unitOfWork.Products
                .Find(x => x.ProductType.Id == _productType.Id &&
                           x.Quantity > _stockAbove);

            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
    }
}