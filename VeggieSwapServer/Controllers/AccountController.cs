using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<UserTokenDTO>> RegisterAsync(RegisterDTO dto)
        {
            return Created("/api/user/{dto.Id}", await _service.RegisterAsync(dto));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserTokenDTO>> LoginAsync(LoginDTO dto)
        {
            return Ok(await _service.LoginAsync(dto.Email, dto.Password));
        }
    }
}