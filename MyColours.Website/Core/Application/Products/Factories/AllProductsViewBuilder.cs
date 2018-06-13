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
    public class AllProductsViewBuilder : IViewBuilder<IEnumerable<ProductViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AllProductsViewBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IEnumerable<ProductViewModel> Build()
        {
            var products = _unitOfWork.Products.GetAll();
            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
    }
}