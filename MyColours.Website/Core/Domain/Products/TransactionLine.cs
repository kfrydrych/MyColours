using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Domain.Products
{
    public class TransactionLine
    {
        protected TransactionLine()
        {
        }

        public TransactionLine(Product product, int quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }

        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public int TransactionId { get; private set; }
        public Transaction Transaction { get; private set; }

        public void DecreaseQuantity(int quantity)
        {
            if (quantity < 1)
                throw new ArgumentException(nameof(quantity));

            if (quantity > Quantity)
                throw new InvalidOperationException("Decrease quantity is higher than current stock");

            Quantity -= quantity;
        }
    }
}