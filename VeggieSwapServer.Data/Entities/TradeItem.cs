namespace VeggieSwapServer.Data.Entities
{
    public class TradeItem : EntityBase
    {
        public int UserId { get; set; }
        public Resource Resource { get; set; }
        public int Amount { get; set; }
    }
}