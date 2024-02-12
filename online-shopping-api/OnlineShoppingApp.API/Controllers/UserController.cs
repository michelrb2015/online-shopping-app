using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.API.Commands;
using OnlineShoppingApp.API.Dtos;
using OnlineShoppingApp.API.Commands.Services;

namespace OnlineShoppingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public UserController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommandDto registerRequest)
        {
            var registerCommand = new RegisterUserCommand
            {
                Username = registerRequest.Username,
                Password = registerRequest.Password,
                Email = registerRequest.Email
            };

            var loginResult = await _mediator.Send(registerCommand);

            if (loginResult is true)
            {
                return Ok("User registered successfully.");
            }
            else
            {
                return BadRequest("Failed to register user.");
            }

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandDto loginRequest)
        {
            var loginCommand = new LoginUserCommand
            {
                Username = loginRequest.Username,
                Password = loginRequest.Password
            };

            var loginResult = await _mediator.Send(loginCommand);

            if (loginResult)
            {
                return Ok(new { Message = "Login successful" });
            }
            else
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }
        }
    }

}
