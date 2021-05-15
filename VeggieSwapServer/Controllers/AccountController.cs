using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Business.Services;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> RegisterAsync(RegisterDTO dto)
        {
            return Created("Hello world", await _service.RegisterAsync(dto));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> LoginAsync(LoginDTO dto)
        {
            return Ok(await _service.LoginAsync(dto.Email, dto.Password));
        }
    }
}