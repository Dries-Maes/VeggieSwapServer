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

        public TradeItemController(TradeItemService tradeItemService)
        {
            _tradeItemService = tradeItemService;
        }

        [HttpGet]
        public async Task<IEnumerable<TradeItemOverviewDto>> GetAllTradeItemsAsync()
        {
            return await _tradeItemService.GetAllEntitiesAsync();
        }

        [HttpGet("detail-list/{id}")]
        public async Task<IEnumerable<TradeItemOverviewDto>> GetTradeItemDetailList(int id)
        {
            return await _tradeItemService.GetTradeItemDetailListDtoAsync(id);
        }
    }
}