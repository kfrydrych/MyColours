using MyColours.Website.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.Domain.Products;
using AutoMapper;

namespace MyColours.Website.Core.Application.Products.Filters
{
    public class ByTypeWithNoStock : Filter<IEnumerable<ProductViewModel>>
    {
        private ProductType _productType;

        public ByTypeWithNoStock(ProductType productType)
        {
            _productType = productType;

        }
        public override IEnumerable<ProductViewModel> FilterFromSource(IUnitOfWork unitOfWork)
        {
            var products = unitOfWork.Products.Find(x => x.ProductType.Id == _productType.Id && 
                                                         x.Quantity == 0);

            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
    }
}