using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Business.Services;

namespace VeggieSwapServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TradeItemController : ControllerBase
    {
        private ITradeItemService _tradeItemService;
        private ITradeFactoryService _tradeFactoryService;

        public TradeItemController(ITradeItemService tradeItemService, ITradeFactoryService tradeFactoryService)
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
        public async Task<ActionResult> AddTradeItemsAsync(ResourceDto addedTradeItem, int id)
        {
            return Ok(await _tradeItemService.AddTradeItemsAsync(addedTradeItem, id));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<TradeItemDto>> GetAllEntitiesAsync()
        {
            return await _tradeItemService.GetAllEntitiesAsync();
        }

        [HttpGet("{id1}/{id2}")]
        public async Task<IEnumerable<TradeItemDto>> ControllerGetsListAsync(int id1, int id2)
        {
            return await _tradeFactoryService.ControllerGetsListAsync(id1, id2);
        }

        [HttpGet("accept/{id1}/{id2}")]
        public async Task<bool> ControllerAcceptTradeAsync(int id1, int id2)
        {
            return await _tradeFactoryService.ControllerAcceptTradeAsync(id1, id2);
        }

        [HttpGet("cancel/{id1}/{id2}")]
        public async Task<bool> ControllerCancelTradeAsync(int id1, int id2)
        {
            return await _tradeFactoryService.ControllerCancelTradeAsync(id1, id2);
        }

        [HttpGet("{id1}")]
        [AllowAnonymous]
        public async Task<IEnumerable<TradeItemDto>> GetTradeItemDetailListDtoAsync(int id1)
        {
            return await _tradeItemService.GetTradeItemDetailListDtoAsync(id1);
        }

        [HttpPost]
        public async Task<ActionResult> ControllerPushListAsync(IEnumerable<TradeItemDto> tradeList)
        {
            return Ok(await _tradeFactoryService.ControllerPushListAsync(tradeList));
        }
    }
}