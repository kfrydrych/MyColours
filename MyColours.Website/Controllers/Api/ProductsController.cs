using CQRS.Core.Commands;
using CQRS.Core.Factories;
using MyColours.Website.Core.Application.Products.Commands;
using MyColours.Website.Core.Application.Products.Filters;
using MyColours.Website.Core.Domain.Products;
using MyColours.Website.Core.ViewModels.Products;
using System.Collections.Generic;
using System.Web.Http;

namespace MyColours.Website.Controllers.Api
{
    public class ProductsController : ApiController
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
        public IHttpActionResult GetById(int id)
        {
            if (id < 1)
                return BadRequest();

            var product = _viewFactory.CreateView<Filter<ProductViewModel>,
                                                         ProductViewModel>(
                                                         new ByProductId(id));

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public IHttpActionResult GetByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest();

            var product = _viewFactory.CreateView<Filter<ProductViewModel>,
                                                         ProductViewModel>(
                                                         new ByProductCode(code));

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public IHttpActionResult GetByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return BadRequest();

            var product = _viewFactory.CreateView<Filter<ProductViewModel>,
                                                         ProductViewModel>(
                                                         new ByProductBarcode(barcode));

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var products = _viewFactory.CreateView<IEnumerable<ProductViewModel>>();
            return Ok(products);
        }

        [HttpGet]
        [Route("Api/ProductsWithStock")]
        public IHttpActionResult ProductsWithStock()
        {
            var products = _viewFactory.CreateView<Filter<IEnumerable<ProductViewModel>>, 
                                                          IEnumerable<ProductViewModel>>(
                                                          new ByTypeWhichStockAbove(ProductType.Colour, 0));
            return Ok(products);
        }

        [HttpPost]
        [Route("Api/Products/Dispose/{id}")]
        public IHttpActionResult Dispose(int id)
        {
            if (id < 1)
                return BadRequest();

            var command = new DisposeProductCommand { Id = id };

            var result = _commandsBus.Send(command);
            return Content(result.StatusCode, result.Message);
        }
    }
}
