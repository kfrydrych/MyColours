using CQRS.Core.Commands;
using System.ComponentModel.DataAnnotations;

namespace MyColours.Website.Core.Application.Products.Commands
{
    public class CreateProductCommand : ICommand
    {
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        [MaxLength(13)]
        public string Barcode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }
    }
}