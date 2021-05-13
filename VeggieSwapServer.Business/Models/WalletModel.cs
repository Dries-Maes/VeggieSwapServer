using System.Collections.Generic;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.Models
{
    public class WalletModel : ModelBase
    {
        public int UserId { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }
        public IEnumerable<Trade> Trades { get; set; }
        public decimal VAmount { get; set; }
    }
}