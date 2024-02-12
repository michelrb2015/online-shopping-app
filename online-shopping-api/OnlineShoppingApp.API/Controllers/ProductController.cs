using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.API.Commands.Services;
using OnlineShoppingApp.API.Queries;

namespace OnlineShoppingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductController(IProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var command = new GetProductsQuery();
                var products = await _mediator.Send(command);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
