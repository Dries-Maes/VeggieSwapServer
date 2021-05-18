using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeggieSwapServer.Data.Entities
{
    public class Purchase : EntityBase
    {
        [ForeignKey("Wallet")]
        public int WalletId { get; set; }

        public virtual Wallet Wallet { get; set; }
        public decimal VAmount { get; set; }
        public decimal EuroAmount { get; set; }
    }
}