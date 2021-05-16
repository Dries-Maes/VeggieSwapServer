using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        //[HttpGet]
        //public async Task<IEnumerable<object>> GetMembersAsync()
        //{
        //    return await _userService.GetAllEntitiesAsync();
        //}

        [HttpGet] //To include in frontend URL => https://localhost:44360/api/User?includeAddress=true
        public async Task<IEnumerable<object>> GetMembersAsyncIncludeAddress(bool includeAddress)
        {
            return await _userService.GetAllEntitiesAsync(includeAddress);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetMemberAsync(int id)
        {
            return Ok(await _userService.GetEntityAsync(id));
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