using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeggieSwapServer.Data.Entities
{
    public class Trade : EntityBase
    {
        public virtual ICollection<TradeItemProposal> TradeItemProposals { get; set; }

        [ForeignKey("User")]
        public int ProposerId { get; set; }

        public virtual User Proposer { get; set; }

        [ForeignKey("User")]
        public int ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        public bool Completed { get; set; }
    }
}