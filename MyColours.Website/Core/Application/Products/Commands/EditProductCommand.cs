using CQRS.Core.Commands;
using MyColours.Website.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Application.Products.Commands
{
    public class EditProductCommand : ICommand
    {
        public int Id { get; set; }

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