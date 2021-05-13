using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Business.Services;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _UserService;
        private IMapper _mapper;

        public UserController(UserService UserService, IMapper mapper)
        {
            _UserService = UserService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetUsersAsync()
        {
            var test = await _UserService.GetAllEntitiesAsync();
            return test;
        }

        //[HttpPost]
        //public async Task AddUser(User User)
        //{
        //    await _UserService.AddEntityAsync(User);
        //}

        [HttpGet("/{id}")]
        public async Task<ActionResult<UserModel>> GetMemberAsync(int id)
        {
            //User UserModel = await _UserService.GetEntityAsync(id);
            //return Ok(member);
            //UserModel mappedModel = _mapper.Map<UserModel>(UserModel);
            //

            //return  Ok(await _UserService.MapUser(id));
            var test = await _UserService.GetEntityAsync(id);
            return Ok(test);
        }
    }
}