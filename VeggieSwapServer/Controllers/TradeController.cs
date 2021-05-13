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
    public class TradeController : ControllerBase
    {
        private TradeService _TradeService;
        private IMapper _mapper;

        public TradeController(TradeService TradeService, IMapper mapper)
        {
            _TradeService = TradeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetTradesAsync()
        {
            var test = await _TradeService.GetAllEntitiesAsync();
            return test;
        }

        //[HttpPost]
        //public async Task AddTrade(Trade Trade)
        //{
        //    await _TradeService.AddEntityAsync(Trade);
        //}

        [HttpGet("/{id}")]
        public async Task<ActionResult<TradeModel>> GetMemberAsync(int id)
        {
            //Trade TradeModel = await _TradeService.GetEntityAsync(id);
            //return Ok(member);
            //TradeModel mappedModel = _mapper.Map<TradeModel>(TradeModel);
            //

            //return  Ok(await _TradeService.MapTrade(id));
            var test = await _TradeService.GetEntityAsync(id);
            return Ok(test);
        }
    }
}