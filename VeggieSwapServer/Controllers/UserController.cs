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
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        //[HttpGet]
        //public async Task<IEnumerable<object>> GetMembersAsync()
        //{
        //    return await _userService.GetAllEntitiesAsync();
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<object>> GetMembersAsyncIncludeAddress(bool includeAddress)
        {
            //include adress in frontend / set bool to true => URL : https://localhost:44360/api/User?includeAddress=true
            return await _userService.GetAllEntitiesAsync(includeAddress);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> GetMemberAsync(int id)
        {
            return Ok(await _userService.GetUserAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> DeleteMemberAsync(int id)
        {
            return Ok(await _userService.DeleteEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostMemberAsync(UserDTO model)
        {
            return Ok(await _userService.AddEntityAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> PutMemberAsync(UserDTO model)
        {
            return Ok(await _userService.UpdateEntityAsync(model));
        }
    }
}