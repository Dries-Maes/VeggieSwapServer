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
    public class ResourceController : ControllerBase
    {
        private ResourceService _ResourceService;
        private IMapper _mapper;

        public ResourceController(ResourceService ResourceService, IMapper mapper)
        {
            _ResourceService = ResourceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetResourcesAsync()
        {
            var test = await _ResourceService.GetAllEntitiesAsync();
            return test;
        }

        //[HttpPost]
        //public async Task AddResource(Resource Resource)
        //{
        //    await _ResourceService.AddEntityAsync(Resource);
        //}

        [HttpGet("/{id}")]
        public async Task<ActionResult<ResourceModel>> GetMemberAsync(int id)
        {
            //Resource ResourceModel = await _ResourceService.GetEntityAsync(id);
            //return Ok(member);
            //ResourceModel mappedModel = _mapper.Map<ResourceModel>(ResourceModel);
            //

            //return  Ok(await _ResourceService.MapResource(id));
            var test = await _ResourceService.GetEntityAsync(id);
            return Ok(test);
        }
    }
}