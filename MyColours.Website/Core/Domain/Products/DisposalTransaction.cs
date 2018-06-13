using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Domain.Products
{
    public class DisposalTransaction : Transaction
    {
        private DisposalTransaction()
        {
        }

        public DisposalTransaction(Product product)
        {
            PurchaseDate = DateTime.Now;
            InvoiceNumber = DateTime.Now.ToString("yyyyMMdd-HHmm-") + product.Code;
            InvoiceValue -= product.Price;
            TransactionTypeId = TransactionType.Disposal.Id;
            TransactionDate = DateTime.Now;
            AddToLine(product, 1, product.Price);
        }
        public override void AddToLine(Product product, int quantity, decimal price)
        {
            Products.Add(new TransactionLine(product, quantity, price));
            product.DecreaseStock(quantity);
        }

        public override void RemoveFromLine(Product product, int quantity)
        {
            var transactionLine = Products.SingleOrDefault(x => x.Product.Id == product.Id);
            transactionLine.DecreaseQuantity(quantity);
            product.IncreaseStock(quantity);
            //DecreaseInvoceValue(product, quantity);
        }
    }
}