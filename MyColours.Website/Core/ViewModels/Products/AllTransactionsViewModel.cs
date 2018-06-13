using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.ViewModels.Products
{
    public class AllTransactionsViewModel
    {
        public decimal StockValue { get; set; }
        public IEnumerable<TransactionViewModel> Transactions { get; set; }
    }
}