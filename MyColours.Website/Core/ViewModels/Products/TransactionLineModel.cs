using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.ViewModels.Products
{
    public class TransactionLineModel
    {
        public int ProductId { get; set; }

        [Display(Name = "Code")]
        public string ProductCode { get; set; }

        [Display(Name = "Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Manufacturer")]
        public string ProductManufacturerName { get; set; }

        [Display(Name = "Type")]
        public string ProductProductTypeName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}