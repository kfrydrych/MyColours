using CQRS.Core.Commands;
using CQRS.Core.Events;
using MyColours.Website.Core.Application.Products.Commands;
using MyColours.Website.Core.Application.Products.Events;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Application.Products.Handlers
{
    public class CreateProductCommandHandler : IHandleCommand<CreateProductCommand>
    {
        private readonly IEventsBus _eventsBus;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IEventsBus eventsBus, IUnitOfWork unitOfWork)
        {
            _eventsBus = eventsBus;
            _unitOfWork = unitOfWork;
        }

        public ICommandResult Handle(CreateProductCommand command)
        {
            var manufacturer = _unitOfWork.Products.GetManufacturer(command.ManufacturerId);
            var productType = _unitOfWork.Products.GetProductType(command.ProductTypeId);

            var product = new Product(command.Code, command.Barcode, command.Description, manufacturer, productType);

            _unitOfWork.Products.Create(product);

            var result = _unitOfWork.Complete();

            if (result == UnitOfWorkResult.Updated)
                PublishProductCreatedEvent(product);

            return CommandResult.Create(result, "Product created");
        }

        private void PublishProductCreatedEvent(Product product)
        {
            _eventsBus.Publish(new ProductCreatedEvent
            {
                ProductId = product.Id,
                Code = product.Code,
                Barcode = product.Barcode,
                Description = product.Description,
                Price = product.Price,
                Manufacturer = product.Manufacturer.Name,
                ProductType = product.ProductType.Name
            });
        }
    }
}