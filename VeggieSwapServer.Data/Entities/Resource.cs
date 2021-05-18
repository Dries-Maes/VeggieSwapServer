using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeggieSwapServer.Data.Entities
{
    public class Resource : EntityBase
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }

        public virtual ICollection<TradeItem> TradeItems { get; set; }
    }
}