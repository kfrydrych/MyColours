using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Domain.Products
{
    public abstract class Transaction
    {
        protected Transaction()
        {
        }

        protected Transaction(DateTime purchaseDate, string invoiceNumber, decimal invoiceValue, TransactionType transactionType)
        {
            PurchaseDate = purchaseDate;
            InvoiceNumber = invoiceNumber;
            InvoiceValue = invoiceValue;
            TransactionTypeId = transactionType.Id;
            TransactionDate = DateTime.Now;
        }

        public int Id { get; protected set; }
        public DateTime PurchaseDate { get; protected set; }
        public DateTime TransactionDate { get; protected set; }
        public string InvoiceNumber { get; protected set; }
        public decimal InvoiceValue { get; protected set; }
        public int TransactionTypeId { get; protected set; }
        public TransactionType TransactionType { get; protected set; }
        public IList<TransactionLine> Products { get; set; } = new List<TransactionLine>();

        public abstract void AddToLine(Product product, int quantity, decimal price);
        public abstract void RemoveFromLine(Product product, int quantity);

        protected virtual void DecreaseInvoceValue(Product product, int quantity)
        {
            InvoiceValue -= (product.Price * quantity);
        }
    }
}