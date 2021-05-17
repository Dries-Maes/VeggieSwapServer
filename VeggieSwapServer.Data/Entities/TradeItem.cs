using System.ComponentModel.DataAnnotations;

namespace VeggieSwapServer.Data.Entities
{
    public class TradeItem : EntityBase
    {
        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public Resource Resource { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}