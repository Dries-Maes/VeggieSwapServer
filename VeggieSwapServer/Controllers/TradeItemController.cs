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
    public class TradeItemController : ControllerBase
    {
        private TradeItemService _tradeItemService;

        public TradeItemController(TradeItemService tradeItemService)
        {
            _tradeItemService = tradeItemService;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetMembersAsync()
        {
            return await _tradeItemService.GetAllEntitiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TradeItemModel>> GetMemberAsync(int id)
        {
            return Ok(await _tradeItemService.GetEntityAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TradeItemModel>> DeleteMemberAsync(int id)
        {
            return Ok(await _tradeItemService.DeleteEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostMemberAsync(TradeItemModel model)
        {
            return Ok(await _tradeItemService.AddEntityAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> PutMemberAsync(TradeItemModel model)
        {
            return Ok(await _tradeItemService.UpdateEntityAsync(model));
        }
    }
}