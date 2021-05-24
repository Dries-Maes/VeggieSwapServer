using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Business.Services;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeItemController : ControllerBase
    {
        private TradeItemService _tradeItemService;
        private ITradeFactoryService _tradeFactoryService;

        public TradeItemController(TradeItemService tradeItemService, ITradeFactoryService tradeFactoryService)
        {
            _tradeFactoryService = tradeFactoryService;
            _tradeItemService = tradeItemService;
        }

        [HttpGet("Resources/")]
        public async Task<IEnumerable<ResourceDto>> GetAllResourcessAsync()
        {
            return await _tradeItemService.GetAllResourcesAsync();
        }

        [HttpPost("Resources/{id}")]
        public async Task<ActionResult> PostMemberAsync(ResourceDto addedTradeItem, int id)
        {
            return Ok(await _tradeItemService.AddTradeItemsAsync(addedTradeItem, id));
        }

        [HttpGet]
        public async Task<IEnumerable<TradeItemDto>> GetAllTradeItemsAsync()
        {
            return await _tradeItemService.GetAllEntitiesAsync();
        }

        [HttpGet("{id1}/{id2}")]
        public async Task<IEnumerable<TradeItemDto>> GetTradeItemDetailList(int id1, int id2)
        {
            return await _tradeFactoryService.ControllerGetsList(id1, id2);
        }

        [HttpGet("accept/{id1}/{id2}")]
        public async Task<bool> AcceptTrade(int id1, int id2)
        {
            return await _tradeFactoryService.ControllerAcceptTradeAsync(id1, id2);
        }

        [HttpGet("cancel/{id1}/{id2}")]
        public async Task<bool> CancelTrade(int id1, int id2)
        {
            return await _tradeFactoryService.ControllerCancelTradeAsync(id1, id2);
        }

        [HttpGet("{id1}")]
        public async Task<IEnumerable<TradeItemDto>> GetTradeItemDetailList(int id1)
        {
            return await _tradeItemService.GetTradeItemDetailListDtoAsync(id1);
        }

        [HttpPost]
        public async Task<ActionResult> PostMemberAsync(IEnumerable<TradeItemDto> tradeList)
        {
            return Ok(await _tradeFactoryService.ControllerPushListAsync(tradeList));
        }
    }
}