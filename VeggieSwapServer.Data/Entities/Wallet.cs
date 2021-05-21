using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeggieSwapServer.Data.Entities
{
    public class Wallet : EntityBase
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public decimal VAmount { get; set; }
    }
}