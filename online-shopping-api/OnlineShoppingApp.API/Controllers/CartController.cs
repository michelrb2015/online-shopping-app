using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.API.Commands;
using OnlineShoppingApp.API.Commands.Services;
using OnlineShoppingApp.API.Dtos;
using OnlineShoppingApp.API.Queries;
using OnlineShoppingApp.Domain.Aggregates;
using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IMediator _mediator;


        public CartController(ICartService cartService, IMediator mediator)
        {
            _cartService = cartService;
            _mediator = mediator;
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetCartItems(int userId)
        {
            try
            {
                var command = new GetCartItemsQuery() { userId = userId };
                var products = await _mediator.Send(command);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto cartDto)
        {
            try
            {
                var addToCartCommand = new AddToCartCommand()
                {
                    UserId = cartDto.UserId,
                    ProductId = cartDto.ProductId
                };

                var addtoCartResult = await _mediator.Send(addToCartCommand);
                if (addtoCartResult)
                {
                    return Ok(new { Message = "Product added to cart successfully." });
                }
                else
                {
                    return BadRequest(new { Message = "Failed to add product to cart." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveFromCart([FromBody] AddToCartDto cartDto)
        {
            try
            {
                var removeFromCartCommand = new RemoveFromCartCommand()
                {
                    UserId = cartDto.UserId,
                    ProductId = cartDto.ProductId
                };

                var removeFromCartResult = await _mediator.Send(removeFromCartCommand);
                if (removeFromCartResult)
                {
                    return Ok(new { Message = "Product removed from cart successfully." });
                }
                else
                {
                    return BadRequest(new { Message = "Failed to remove product from cart." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
