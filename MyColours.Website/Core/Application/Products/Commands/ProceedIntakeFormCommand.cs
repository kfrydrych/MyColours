using CQRS.Core.Commands;
using FluentValidation.Attributes;
using MyColours.Website.Core.Validation.Products;
using MyColours.Website.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Application.Products.Commands
{
    [Validator(typeof(IntakeFormValidator))]
    public class ProceedIntakeFormCommand : ICommand
    {
        [Display(Name = "Purchase Date")]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Invoice Value")]
        public decimal InvoiceValue { get; set; }

        public IList<ProductInBasketModel> Basket { get; set; } = new List<ProductInBasketModel>();
    }
}