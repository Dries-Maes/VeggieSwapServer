using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data.Repositories
{
    public interface ITradeItemRepo : IGenericRepo<TradeItem>
    {
        Task<IEnumerable<TradeItem>> GetAllTradeItemsByUserIdAsync(int id);
    }
}