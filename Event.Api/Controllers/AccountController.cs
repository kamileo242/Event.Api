﻿using Evento.Infrastructure.Commands.Users;
using Evento.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITicketService _ticketService;
        public AccountController(IUserService userService, ITicketService ticketService)
        {
            _userService = userService;
            _ticketService= ticketService;  
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
            => Json(await _userService.GetAccountAsync(UserId));

        [HttpGet("tickets")]
        [Authorize]
        public async Task<IActionResult> GetTickets()
            =>Json(await _ticketService.GetForUserAsync(UserId));

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


