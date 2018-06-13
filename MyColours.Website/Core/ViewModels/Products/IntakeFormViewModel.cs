using MyColours.Website.Core.Application.Products.Commands;
using System.Collections.Generic;

namespace MyColours.Website.Core.ViewModels.Products
{

    public class IntakeFormViewModel : ProceedIntakeFormCommand
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}