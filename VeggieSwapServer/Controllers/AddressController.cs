using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private IGenericService<Address> _AddressService;
        private IMapper _mapper;

        public AddressController(IGenericService<Address> genericService, IMapper mapper)
        {
            _AddressService = genericService;
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

            Address addressModel = await _AddressService.GetEntityAsync(id);
            //return Ok(member);
            AddressModel mappedModel = _mapper.Map<AddressModel>(addressModel);
            int tismijbeu = 0;
            return Ok(mappedModel);
        }
    }
}