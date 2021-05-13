using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Business.Services;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResourceController : ControllerBase
    {
        private ResourceService _addressService;

        public ResourceController(ResourceService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetResourceesAsync()
        {
            var test = await _addressService.GetAllEntitiesAsync();
            return test;
        }

        //[HttpPost]
        //public async Task AddResource(Resource Resource)
        //{
        //    await _ResourceService.AddEntityAsync(Resource);
        //}

        //[HttpGet("/{id}")]
        //public async Task<ActionResult<ResourceModel>> GetMemberAsync(int id)
        //{
        //    //Resource addressModel = await _addressService.GetEntityAsync(id);
        //    //return Ok(member);
        //    //ResourceModel mappedModel = _mapper.Map<ResourceModel>(addressModel);
        //    //

        //    //return  Ok(await _addressService.MapResource(id));
        //    var test = await _addressService.GetEntityAsync(id);
        //    return Ok(test);
        //}
    }
}