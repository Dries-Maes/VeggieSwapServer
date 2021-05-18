using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeggieSwapServer.Data.Entities
{
    public class TradeItemProposal : EntityBase
    {
        [ForeignKey("TradeItem")]
        public int TradeItemId { get; set; }

        public virtual TradeItem TradeItem { get; set; }

        [ForeignKey("Trade")]
        public int TradeId { get; set; }

        public virtual Trade Trade { get; set; }

        [Required]
        public int ProposedAmount { get; set; }
    }
}