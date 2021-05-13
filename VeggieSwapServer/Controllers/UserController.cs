using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Business.Services;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetUsersAsync()
        {
            return await _userService.GetAllEntitiesAsync();
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<object>> GetUserAsync(int id)
        {
            var test = await _userService.GetEntityAsync(id);
            return Ok(test);
        }
    }
}