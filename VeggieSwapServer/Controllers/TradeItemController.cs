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

        [HttpGet]
        public async Task<IEnumerable<TradeItemDto>> GetAllTradeItemsAsync()
        {
            return await _tradeItemService.GetAllEntitiesAsync();
        }

        [HttpGet("detail-list/{id1}/{id2}")]
        public async Task<IEnumerable<TradeItemDto>> GetTradeItemDetailList(int id1, int id2)
        {
            return await _tradeFactoryService.ControllerGetsList(id1, id2);
        }

        [HttpPost]
        public async Task<ActionResult> PostMemberAsync(IEnumerable<TradeItemDto> tradeList)
        {
            return Ok(await _tradeFactoryService.ControllerPushListAsync(tradeList));
        }
    }
}