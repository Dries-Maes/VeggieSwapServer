using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace VeggieSwapServer.Data.Repositories
{
    public class TradeItemRepo : GenericRepo<TradeItem>
    {
        public TradeItemRepo(VeggieSwapServerContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<TradeItem>> GetTradeItemsAsync(bool sold)
        {
            return await _context.Set<TradeItem>().Include(x => x.Resource).Where(x => x.Sold == sold).ToListAsync();
        }

        public override async Task<IEnumerable<TradeItem>> GetAllEntitiesAsync()
        {
            return await _context.Set<TradeItem>().Include(x => x.Resource).ToListAsync();
        }
    }
}