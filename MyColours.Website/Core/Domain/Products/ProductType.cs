using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Domain.Products
{
    public class ProductType
    {
        private ProductType()
        { 
        }

        private ProductType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public static ProductType Colour => new ProductType(1, "Colour");
    }
}