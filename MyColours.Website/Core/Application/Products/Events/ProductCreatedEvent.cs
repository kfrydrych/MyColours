using CQRS.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Application.Products.Events
{
    public class ProductCreatedEvent : IEvent
    {
        public int ProductId { get; set; }

        public string Code { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Manufacturer { get; set; }

        public string ProductType { get; set; }
    }
}