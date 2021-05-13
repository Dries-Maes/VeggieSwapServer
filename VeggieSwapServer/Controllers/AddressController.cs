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
    public class AddressController : ControllerBase
    {
        private AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetAddressesAsync()
        {
            return await _addressService.GetAllEntitiesAsync();
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<AddressModel>> GetMemberAsync(int id)
        {
            return Ok(await _addressService.GetEntityAsync(id));
        }
    }
}