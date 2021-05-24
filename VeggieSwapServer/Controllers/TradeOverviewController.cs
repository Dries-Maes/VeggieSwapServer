using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Business.Services;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TradeOverviewController : ControllerBase
    {
        private ITradeOverviewService _tradeOverviewService;

        public TradeOverviewController(ITradeOverviewService tradeOverviewService)
        {
            _tradeOverviewService = tradeOverviewService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<TradeDto>> GetTradeOverview(int id)
        {
            return await _tradeOverviewService.ControllerGetsList(id);
        }
    }
}