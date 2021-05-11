using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private IGenericService<Address> _AddressService;

        public AddressController(IGenericService<Address> genericService)
        {
            _AddressService = genericService;
        }

        [HttpGet]
        public async Task<IEnumerable<Address>> GetAddresssAsync()
        {
            return await _AddressService.GetAllItemsAsync();
        }

        [HttpPost]
        public async Task AddAddress(Address Address)
        {
            await _AddressService.AddItemAsync(Address);
        }
    }
}