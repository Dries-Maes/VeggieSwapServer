using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;

namespace VeggieSwapServer.Business.Services
{
    public interface ITradeOverviewService
    {
        IEnumerable<TradeDto> ControllerGetsList(int userId);
    }
}