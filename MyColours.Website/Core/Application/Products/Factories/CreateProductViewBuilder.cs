using CQRS.Core.Factories;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Application.Products.Factories
{
    public class CreateProductViewBuilder : IViewBuilder<CreateProductViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductViewBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateProductViewModel Build()
        {
            var model = new CreateProductViewModel
            {
                Manufacturers = _unitOfWork.Products.GetAllManufacturers(),
                ProductTypes = _unitOfWork.Products.GetAllProductTypes()
            };

            return model;
        }
    }
}