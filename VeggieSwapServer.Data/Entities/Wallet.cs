using System.Collections.Generic;

namespace VeggieSwapServer.Data.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<Trade> Trades { get; set; }
        public decimal VAmount { get; set; }
    }
}