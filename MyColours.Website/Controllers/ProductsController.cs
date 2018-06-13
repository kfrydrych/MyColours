using CQRS.Core.Commands;
using CQRS.Core.Factories;
using MyColours.Website.Common.Filters;
using MyColours.Website.Core.Application.Products.Commands;
using MyColours.Website.Core.ViewModels.Products;
using MyColours.Website.Toast;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyColours.Website.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ICommandsBus _commandsBus;
        private readonly IViewFactory _viewFactory;

        public ProductsController(ICommandsBus commandsBus, 
                                  IViewFactory viewFactory)
        {
            _commandsBus = commandsBus;
            _viewFactory = viewFactory;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = _viewFactory.CreateView<IEnumerable<ProductViewModel>>();
            return View(viewModel);
        }

        [HttpGet]
        [ImportModelStateFromTempData]
        public ActionResult Create()
        {
            var viewModel = _viewFactory.CreateView<CreateProductViewModel>();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateModelState]
        public ActionResult Create(CreateProductCommand command)
        {
            var result = _commandsBus.Send(command);
            this.AddToastMessage(result);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ImportModelStateFromTempData]
        public ActionResult Edit(int id)
        {
            var viewModel = _viewFactory.CreateView<int, EditProductViewModel>(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateModelState]
        public ActionResult Edit(EditProductCommand command)
        {
            var result = _commandsBus.Send(command);
            this.AddToastMessage(result);
            return RedirectToAction(nameof(Index));
        }
    }
}