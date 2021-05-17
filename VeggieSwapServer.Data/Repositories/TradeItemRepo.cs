using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async override Task<IEnumerable<TradeItem>> GetAllEntitiesAsync()
        {
            return await _context.Set<TradeItem>()
                .Include(x => x.Resource)
                .Include(y => y.User)
                .ToListAsync();
        }
    }
}