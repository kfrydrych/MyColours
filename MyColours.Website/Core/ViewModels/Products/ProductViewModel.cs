using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        [Display(Name = "Manufacturer")]
        public string ManufacturerName { get; set; }

        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; }

        [Display(Name = "Current Stock")]
        public int Quantity { get; set; }
    }
}