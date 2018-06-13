using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.ViewModels.Products
{
    public class ProductInBasketModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}