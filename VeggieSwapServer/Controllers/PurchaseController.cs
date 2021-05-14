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
    public class PurchaseController : ControllerBase
    {
        private PurchaseService _purchaseService;

        public PurchaseController(PurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetMembersAsync()
        {
            return await _purchaseService.GetAllEntitiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseModel>> GetMemberAsync(int id)
        {
            return Ok(await _purchaseService.GetEntityAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseModel>> DeleteMemberAsync(int id)
        {
            return Ok(await _purchaseService.DeleteEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostMemberAsync(PurchaseModel model)
        {
            await _purchaseService.AddEntityAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutMemberAsync(PurchaseModel model)
        {
            model.ModifiedAt = DateTime.Now;
            await _purchaseService.UpdateEntityAsync(model);
            return Ok();
        }
    }
}