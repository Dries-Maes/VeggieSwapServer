using System.Collections.Generic;

namespace VeggieSwapServer.Data.Entities
{
    public class Wallet : EntityBase
    {
        public int UserId { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }
        public IEnumerable<Trade> Trades { get; set; }
        public decimal VAmount { get; set; }
    }
}