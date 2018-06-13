using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.ViewModels.Products
{
    public class DashboardModel
    {
        public IEnumerable<ProductViewModel> LowStockColours { get; set; }
        public IEnumerable<ProductViewModel> NoStockColours { get; set; }
    }
}