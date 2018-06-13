using CQRS.Core.Events;
using MyColours.Website.Core.Application.Products.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.EmailService.Handlers
{
    public class WhenProductCreated_SendNotificationEmail : IHandleEvent<ProductCreatedEvent>
    {
        public void Handle(ProductCreatedEvent @event)
        {
            // TO DO: Logic to send an email
        }
    }
}