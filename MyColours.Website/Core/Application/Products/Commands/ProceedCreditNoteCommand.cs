using CQRS.Core.Commands;
using MyColours.Website.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Application.Products.Commands
{
    public class ProceedCreditNoteCommand : ICommand
    {
        public int TransactionId { get; set; }

        public IEnumerable<TransactionLineModel> Products { get; set; }
    }
}