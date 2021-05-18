using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeggieSwapServer.Data.Entities
{
    public class TradeItem : EntityBase
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Resource")]
        public int ResourceId { get; set; }

        public virtual Resource Resource { get; set; }

        [Required]
        public int Amount { get; set; }

        [ForeignKey("Trade")]
        public virtual ICollection<TradeItemProposal> TradeItemProposals { get; set; }

        public bool Sold { get; set; }
    }
}