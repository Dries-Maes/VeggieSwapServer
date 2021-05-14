using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private ResourceService _resourceService;

        public ResourceController(ResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetMembersAsync()
        {
            return await _resourceService.GetAllEntitiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResourceModel>> GetMemberAsync(int id)
        {
            return Ok(await _resourceService.GetEntityAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResourceModel>> DeleteMemberAsync(int id)
        {
            return Ok(await _resourceService.DeleteEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostMemberAsync(ResourceModel model)
        {
            await _resourceService.AddEntityAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutMemberAsync(ResourceModel model)
        {
            model.ModifiedAt = DateTime.Now;
            await _resourceService.UpdateEntityAsync(model);
            return Ok();
        }
    }
}