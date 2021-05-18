using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeggieSwapServer.Data.Entities
{
    public class TradeItem : EntityBase
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("Resource")]
        public int ResourceId { get; set; }

        public Resource Resource { get; set; }

        [Required]
        public int Amount { get; set; }

        [ForeignKey("Trade")]
        public int TradeId { get; set; }

        public Trade Trade { get; set; }
    }
}