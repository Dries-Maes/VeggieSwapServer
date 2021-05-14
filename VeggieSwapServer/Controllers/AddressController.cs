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
    public class AddressController : ControllerBase
    {
        private AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetMembersAsync()
        {
            return await _addressService.GetAllEntitiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressModel>> GetMemberAsync(int id)
        {
            return Ok(await _addressService.GetEntityAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AddressModel>> DeleteMemberAsync(int id)
        {
            return Ok(await _addressService.DeleteEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostMemberAsync(AddressModel model)
        {
            return Ok(await _addressService.AddEntityAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> PutMemberAsync(AddressModel model)
        {
            return Ok(await _addressService.UpdateEntityAsync(model));
        }
    }
}