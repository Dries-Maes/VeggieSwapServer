using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data.Repositories
{
    public class TradeRepo : GenericRepo<Trade>
    {
        public TradeRepo(VeggieSwapServerContext context)
            : base(context)
        {
        }

        public async Task<Trade> GetTradeListFromUserAsync(int userID)
        {
            return null;
        }

        public async Task<Trade> GetTradeAsync(int trader1, int trader2)
        {
            return _context.Set<Trade>()
                .Where(x => x.ProposerId == trader1 | x.ProposerId == trader2)
                .Where(x => x.ReceiverId == trader1 | x.ReceiverId == trader2)
                .FirstOrDefault(y => !y.Completed);
        }
    }
}