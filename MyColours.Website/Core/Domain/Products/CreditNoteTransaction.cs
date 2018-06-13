using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Domain.Products
{
    public class CreditNoteTransaction : Transaction
    {
        private readonly TransactionType _creditedTransactionType;

        private CreditNoteTransaction()
        {
        }

        public CreditNoteTransaction(DateTime purchaseDate, string invoiceNumber, TransactionType creditedTransactionType)
            : base(purchaseDate, invoiceNumber, 0, TransactionType.CreditNote)
        {
            _creditedTransactionType = creditedTransactionType;
        }


        public override void AddToLine(Product product, int quantity, decimal price)
        {
            Products.Add(new TransactionLine(product, quantity, price));
            UpdateCreditNoteValue(quantity, price);
        }

        public override void RemoveFromLine(Product product, int quantity)
        {
            var transactionLine = Products.SingleOrDefault(x => x.Product.Id == product.Id);
            transactionLine.DecreaseQuantity(quantity);
        }

        private void UpdateCreditNoteValue(int quantity, decimal price)
        {
            if (_creditedTransactionType.Id.Equals(TransactionType.Intake.Id))
                InvoiceValue -= (quantity * price);
            else
                InvoiceValue += (quantity * price);
        }
    }
}