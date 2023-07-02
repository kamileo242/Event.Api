using Evento.Infrastructure.Commands.Users;
using Evento.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        => Json(await _userService.GetAccountAsync(UserId));

        [HttpGet("tickets")]
        public async Task<IActionResult> GetTickets()
        {
            throw new NotImplementedException();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] Register command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Role, command.Name, command.Email, command.Password);

            return Created("/account", null);
        }
      
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] Login command)
        => Json(await _userService.LoginAsync(command.Email, command.Password));
    }
}


