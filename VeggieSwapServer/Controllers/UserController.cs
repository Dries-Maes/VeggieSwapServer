using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IGenericService<User> _userService;

        public UserController(IGenericService<User> userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _userService.GetAllItemsAsync();
        }

        [HttpPost]
        public async Task AddUser(User user)
        {
            await _userService.AddItemAsync(user);
        }
    }
}