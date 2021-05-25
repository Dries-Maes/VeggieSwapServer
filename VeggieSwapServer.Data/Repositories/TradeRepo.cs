using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data.Repositories
{
    public class TradeRepo : GenericRepo<Trade>, ITradeRepo
    {
        public TradeRepo(VeggieSwapServerContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Trade>> GetTradeListFromUserAsync(int userID)
        {
            return _context.Set<Trade>()
                 .Where(x => x.ProposerId == userID | x.ReceiverId == userID)
                 .Include(x => x.TradeItemProposals)
                 .ThenInclude(x => x.TradeItem)
                 .ThenInclude(x => x.Resource)
                 .Include(x => x.Proposer)
                 .ThenInclude(x => x.Address)
                 .Include(x => x.Receiver)
                 .ThenInclude(x => x.Address);
        }

        public async Task<Trade> GetTradeAsync(int trader1, int trader2)
        {
            return await _context.Set<Trade>()
                .Where(x => x.ProposerId == trader1 | x.ProposerId == trader2)
                .Where(x => x.ReceiverId == trader1 | x.ReceiverId == trader2)
                .FirstOrDefaultAsync(y => !y.Completed);
        }
    }
}