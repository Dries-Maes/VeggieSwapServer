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
        private IMapper _mapper;

        public AddressController(AddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<IEnumerable<AddressModel>> GetAddresssAsync()
        //{
        //    return await _AddressService.GetAllEntitiesAsync();
        //}

        //[HttpPost]
        //public async Task AddAddress(Address Address)
        //{
        //    await _AddressService.AddEntityAsync(Address);
        //}

        [HttpGet("/{id}")]
        public async Task<ActionResult<AddressModel>> GetMemberAsync(int id)
        {

            //Address addressModel = await _addressService.GetEntityAsync(id);
            //return Ok(member);
            //AddressModel mappedModel = _mapper.Map<AddressModel>(addressModel);
            //

            return  Ok(await _addressService.MapAddress(id));
        }
    }
}