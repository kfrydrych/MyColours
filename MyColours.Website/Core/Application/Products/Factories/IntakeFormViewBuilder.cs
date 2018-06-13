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
    public class IntakeFormViewBuilder : IViewBuilder<IntakeFormViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public IntakeFormViewBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IntakeFormViewModel Build()
        {
            var products = _unitOfWork.Products.GetAll();

            return new IntakeFormViewModel
            {
                Products = Mapper.Map<IEnumerable<ProductViewModel>>(products)
            };
        }
    }
}