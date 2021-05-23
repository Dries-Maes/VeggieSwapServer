using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data.Repositories
{
    public class TradeItemRepo : GenericRepo<TradeItem>
    {
        public TradeItemRepo(VeggieSwapServerContext context)
            : base(context)
        {
        }

        public override async Task<IEnumerable<TradeItem>> GetAllEntitiesAsync()
        {
            return await _context.Set<TradeItem>()
                .Include(x => x.Resource)
                .Include(x => x.User)
                .ThenInclude(x => x.Address)
                .ToListAsync();
        }

        public async Task<IEnumerable<TradeItem>> GetAllTradeItemsByUserIdAsync(int id)
        {
            return await _context.Set<TradeItem>().Include(x => x.Resource).Where(x => x.UserId == id).ToListAsync();
        }
    }
}