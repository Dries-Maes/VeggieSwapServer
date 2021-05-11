using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeController : ControllerBase
    {
        private IGenericService<Trade> _tradeService;

        public TradeController(GenericService<Trade> genericService)
        {
            _tradeService = genericService;
        }

        [HttpGet]
        public async Task<IEnumerable<Trade>> GetTradesAsync()
        {
            return await _tradeService.GetAllItemsAsync();
        }

        [HttpPost]
        public async Task AddTrade(Trade trade)
        {
            await _tradeService.AddItemAsync(trade);
        }
    }
}