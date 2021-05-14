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
    public class TradeController : ControllerBase
    {
        private TradeService _tradeService;

        public TradeController(TradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetMembersAsync()
        {
            return await _tradeService.GetAllEntitiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TradeModel>> GetMemberAsync(int id)
        {
            return Ok(await _tradeService.GetEntityAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TradeModel>> DeleteMemberAsync(int id)
        {
            return Ok(await _tradeService.DeleteEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostMemberAsync(TradeModel model)
        {
            await _tradeService.AddEntityAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutMemberAsync(TradeModel model)
        {
            model.ModifiedAt = DateTime.Now;
            await _tradeService.UpdateEntityAsync(model);
            return Ok();
        }
    }
}