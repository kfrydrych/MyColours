using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.ViewModels.Products
{
    public class TransactionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Type")]
        public string TransactionTypeName { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Transaction Number")]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Transaction Value")]
        public decimal InvoiceValue { get; set; }
    }
}