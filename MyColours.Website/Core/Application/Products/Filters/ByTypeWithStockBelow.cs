using MyColours.Website.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.Domain.Products;
using AutoMapper;

namespace MyColours.Website.Core.Application.Products.Filters
{
    public class ByTypeWithStockBelow : Filter<IEnumerable<ProductViewModel>>
    {
        private ProductType _productType;
        private int _stockBelow;

        public ByTypeWithStockBelow(ProductType productType, int stockBelow)
        {
            _productType = productType;
            _stockBelow = stockBelow;
        }

        public override IEnumerable<ProductViewModel> FilterFromSource(IUnitOfWork unitOfWork)
        {
            var products = unitOfWork.Products
                .Find(x => x.ProductType.Id == _productType.Id &&
                           x.Quantity < _stockBelow &&
                           x.Quantity > 0);

            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
    }
}