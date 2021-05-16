using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeggieSwapServer.Data.Entities
{
    public class Wallet : EntityBase
    {
        [Required]
        public int UserId { get; set; }

        public IEnumerable<Purchase> Purchases { get; set; }
        public IEnumerable<Trade> Trades { get; set; }
        public decimal VAmount { get; set; }
    }
}