using MyColours.Website.Core.Application.Products.Commands;
using MyColours.Website.Core.Domain.Products;
using System.Collections.Generic;

namespace MyColours.Website.Core.ViewModels.Products
{
    public class CreateProductViewModel : CreateProductCommand
    {
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
    }
}