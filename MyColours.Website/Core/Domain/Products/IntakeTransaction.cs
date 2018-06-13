using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Domain.Products
{
    public class IntakeTransaction : Transaction
    {
        private IntakeTransaction()
        {
        }

        public IntakeTransaction(DateTime purchaseDate, string invoiceNumber, decimal invoiceValue)
            : base(purchaseDate, invoiceNumber, invoiceValue, TransactionType.Intake)
        {
        }

        public override void AddToLine(Product product, int quantity, decimal price)
        {
            Products.Add(new TransactionLine(product, quantity, price));
            product.IncreaseStock(quantity);
        }

        public override void RemoveFromLine(Product product, int quantity)
        {
            var transactionLine = Products.SingleOrDefault(x => x.Product.Id == product.Id);
            transactionLine.DecreaseQuantity(quantity);
            product.DecreaseStock(quantity);
            //DecreaseInvoceValue(product, quantity);
        }
    }
}