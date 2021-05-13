using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.Models
{
    public class TradeItemModel : ModelBase
    {
        public int UserId { get; set; }
        public Resource Resource { get; set; }
        public int Amount { get; set; }
    }
}