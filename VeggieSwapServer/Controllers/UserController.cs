using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Business.Services;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetAllEntitiesAsync(bool includeAddress)
        {
            return await _userService.GetAllEntitiesAsync(includeAddress);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserAsync(int id)
        {
            return Ok(await _userService.GetUserAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteEntityAsync(int id)
        {
            return Ok(await _userService.DeleteEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddEntityAsync(UserDto model)
        {
            return Ok(await _userService.AddEntityAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEntityAsync(UserDto model)
        {
            return Ok(await _userService.UpdateEntityAsync(model));
        }
    }
}