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
    public class ProductTransactionsController : Controller
    {
        private readonly ICommandsBus _commandsBus;
        private readonly IViewFactory _viewFactory;

        public ProductTransactionsController(ICommandsBus commandsBus,
                                             IViewFactory viewFactory)
        {
            _commandsBus = commandsBus;
            _viewFactory = viewFactory;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = _viewFactory.CreateView<IEnumerable<TransactionViewModel>>();
            return View(viewModel);
        }

        [HttpGet]
        [ImportModelStateFromTempData]
        public ActionResult Create()
        {
            var viewModel = _viewFactory.CreateView<IntakeFormViewModel>();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateModelState]
        public ActionResult Create(IntakeFormViewModel viewModel)
        {
            // Because Form is being posted by JavaScript,
            // the command cannot be set as parameter.
            // It looks like it has to be the same model in and out - needs some research!

            var command = new ProceedIntakeFormCommand
            {
                PurchaseDate = viewModel.PurchaseDate,
                InvoiceNumber = viewModel.InvoiceNumber,
                InvoiceValue = viewModel.InvoiceValue,
                Basket = viewModel.Basket
            };

            var result = _commandsBus.Send(command);
            this.AddToastMessage(result);
            return Json(Url.Action(nameof(Index), "ProductTransactions"));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var viewModel = _viewFactory.CreateView<int, TransactionDetailsViewModel>(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Credit(int id)
        {
            var viewModel = _viewFactory.CreateView<int, CreditNoteFormViewModel>(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateModelState]
        public ActionResult Credit(CreditNoteFormViewModel viewModel)
        {
            var command = new ProceedCreditNoteCommand
            {
                TransactionId = viewModel.TransactionId,
                Products = viewModel.Products
            };

            var result = _commandsBus.Send(command);
            this.AddToastMessage(result);
            return Json(Url.Action(nameof(Index), "ProductTransactions"));
        }
    }
}