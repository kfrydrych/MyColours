using CQRS.Core.Factories;
using MyColours.Website.Core.Application.Products.Filters;
using MyColours.Website.Core.Domain.Products;
using MyColours.Website.Core.ViewModels.Products;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyColours.Website.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IViewFactory _viewFactory;

        public DashboardController(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new DashboardModel
            {
                LowStockColours = _viewFactory.CreateView<Filter<IEnumerable<ProductViewModel>>, 
                                                                 IEnumerable<ProductViewModel>>(
                                                                 new ByTypeWithStockBelow(ProductType.Colour, 5)),

                NoStockColours = _viewFactory.CreateView<Filter<IEnumerable<ProductViewModel>>, 
                                                                IEnumerable<ProductViewModel>>(
                                                                new ByTypeWithNoStock(ProductType.Colour))
            };

            return View(viewModel);
        }
    }
}