using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}