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

        [HttpGet]
        public async Task<IEnumerable<object>> GetMembersAsyncIncludeAddress(bool includeAddress)
        {
            return await _userService.GetAllEntitiesAsync(includeAddress);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetMemberAsync(int id)
        {
            return Ok(await _userService.GetEntityAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteMemberAsync(int id)
        {
            return Ok(await _userService.DeleteEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostMemberAsync(UserModel model)
        {
            return Ok(await _userService.AddEntityAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> PutMemberAsync(UserModel model)
        {
            return Ok(await _userService.UpdateEntityAsync(model));
        }
    }
}