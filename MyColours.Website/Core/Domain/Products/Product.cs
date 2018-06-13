using MyColours.Website.Core.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Domain.Products
{
    public class Product
    {
        protected Product()
        {
        }

        public Product(string code, string barcode, string description, Manufacturer manufacturer, ProductType productType)
        {
            Code = code;
            Barcode = barcode;
            Description = description;
            Manufacturer = manufacturer;
            ProductType = productType;
        }

        public void Edit(string code, string barcode, string description, Manufacturer manufacturer, ProductType productType)
        {
            Code = code;
            Barcode = barcode;
            Description = description;
            Manufacturer = manufacturer;
            ProductType = productType;
        }

        public int Id { get; private set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; private set; }

        [Required]
        [MaxLength(13)]
        public string Barcode { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; private set; }

        public decimal Price { get; private set; }

        [Required]
        public Manufacturer Manufacturer { get; private set; }

        [Required]
        public ProductType ProductType { get; private set; }

        public int Quantity { get; private set; }

        public void IncreaseStock(int quantity)
        {
            if (quantity < 1)
                throw new ArgumentException(nameof(quantity));

            Quantity += quantity;
        }

        public void DecreaseStock(int quantity)
        {
            if (quantity < 1)
                throw new ArgumentException(nameof(quantity));

            if (quantity > Quantity)
                throw new InvalidOperationException("Decrease quantity is higher than current stock");

            Quantity -= quantity;
        }

        public void UpdatePrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price cannot be 0 or negative");

            Price = price;
        }
    }
}