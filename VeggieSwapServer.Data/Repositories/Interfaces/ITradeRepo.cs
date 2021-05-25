using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data.Repositories
{
    public interface ITradeRepo : IGenericRepo<Trade>
    {
        Task<Trade> GetTradeAsync(int trader1, int trader2);

        Task<IEnumerable<Trade>> GetTradeListFromUserAsync(int userID);
    }
}