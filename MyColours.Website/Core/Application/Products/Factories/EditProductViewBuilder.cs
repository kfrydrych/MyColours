using AutoMapper;
using CQRS.Core.Factories;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.ViewModels.Products;

namespace MyColours.Website.Core.Application.Products.Factories
{
    public class EditProductViewBuilder : IViewBuilder<int, EditProductViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditProductViewBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public EditProductViewModel Build(int productId)
        {
            var product = _unitOfWork.Products.Get(productId);

            var model = Mapper.Map<EditProductViewModel>(product);
            model.Manufacturers = _unitOfWork.Products.GetAllManufacturers();
            model.ProductTypes = _unitOfWork.Products.GetAllProductTypes();

            return model;
        }
    }
}