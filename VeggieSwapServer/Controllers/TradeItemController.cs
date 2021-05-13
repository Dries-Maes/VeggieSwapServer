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
    public class TradeItemController : ControllerBase
    {
        private TradeItemService _TradeItemService;
        private IMapper _mapper;

        public TradeItemController(TradeItemService TradeItemService, IMapper mapper)
        {
            _TradeItemService = TradeItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetTradeItemsAsync()
        {
            var test = await _TradeItemService.GetAllEntitiesAsync();
            return test;
        }

        //[HttpPost]
        //public async Task AddTradeItem(TradeItem TradeItem)
        //{
        //    await _TradeItemService.AddEntityAsync(TradeItem);
        //}

        [HttpGet("/{id}")]
        public async Task<ActionResult<TradeItemModel>> GetMemberAsync(int id)
        {
            //TradeItem TradeItemModel = await _TradeItemService.GetEntityAsync(id);
            //return Ok(member);
            //TradeItemModel mappedModel = _mapper.Map<TradeItemModel>(TradeItemModel);
            //

            //return  Ok(await _TradeItemService.MapTradeItem(id));
            var test = await _TradeItemService.GetEntityAsync(id);
            return Ok(test);
        }
    }
}