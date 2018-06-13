using CQRS.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Application.Products.Commands
{
    public class DisposeProductCommand : ICommand
    {
        public int Id { get; set; }
    }
}