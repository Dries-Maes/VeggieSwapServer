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
            if (await _service.UserExists(dto.Email))
            {
                return BadRequest("Email already exists");
            }

            var user = await _service.RegisterAsync(dto.Email, dto.Password, dto.FirstName, dto.LastName);
            
            return Created("", user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> LoginAsync(LoginDTO dto)
        {
            try
            {
                UserDto user = await _service.LoginAsync(dto.Email, dto.Password);
                return Ok(user);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
