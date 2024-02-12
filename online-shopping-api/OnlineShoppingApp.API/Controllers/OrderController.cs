using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.API.Commands;
using OnlineShoppingApp.API.Commands.Services;
using OnlineShoppingApp.API.Dtos;
using OnlineShoppingApp.Domain.Aggregates;
using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly IMediator _mediator;

        public OrderController(IOrderService orderService, ICartService cartService, IMediator mediator)
        {
            _orderService = orderService;
            _cartService = cartService;
            _mediator = mediator;
        }

        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderDto placeOrderDto)
        {
            try
            {
                var productsIds = await _cartService.GetProductIdsInCartAsync(placeOrderDto.UserId);

                var placeOrderCommand = new PlaceOrderCommand()
                {
                    UserId = placeOrderDto.UserId,
                    Products = productsIds.ToList(),
                };

                var placeOrderResult = await _mediator.Send(placeOrderCommand);
                if (placeOrderResult)
                {
                    return Ok("Order placed successfully.");
                }
                else
                {
                    return BadRequest("Failed to place order.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
