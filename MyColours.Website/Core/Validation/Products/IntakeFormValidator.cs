using FluentValidation;
using MyColours.Website.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Validation.Products
{
    public class IntakeFormValidator : AbstractValidator<IntakeFormViewModel>
    {
        public IntakeFormValidator()
        {
            RuleFor(x => x.PurchaseDate).NotNull().WithMessage("Purchase Date is required");
            RuleFor(x => x.InvoiceNumber).NotNull().WithMessage("Invoice number is required");
            RuleFor(x => x.InvoiceValue).NotNull().WithMessage("Invoice value is required");
            RuleFor(x => x.Basket).NotEmpty().WithMessage("Invoice require at least one product in basket");
        }
    }
}