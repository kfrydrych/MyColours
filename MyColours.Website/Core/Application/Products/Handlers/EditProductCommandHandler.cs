using AutoMapper;
using CQRS.Core.Commands;
using MyColours.Website.Core.Application.Products.Commands;
using MyColours.Website.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Application.Products.Handlers
{
    public class EditProductCommandHandler : IHandleCommand<EditProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public ICommandResult Handle(EditProductCommand command)
        {
            var product = _unitOfWork.Products.Get(command.Id);
            var manufacturer = _unitOfWork.Products.GetManufacturer(command.ManufacturerId);
            var productType = _unitOfWork.Products.GetProductType(command.ProductTypeId);

            product.Edit(command.Code, command.Barcode, command.Description, manufacturer, productType);

            return CommandResult.Create(_unitOfWork.Complete(), "Product edited");
        }
    }
}