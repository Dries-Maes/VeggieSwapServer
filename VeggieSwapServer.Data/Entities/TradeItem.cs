namespace VeggieSwapServer.Data.Entities
{
    public class TradeItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Resource Resource { get; set; }
        public int Amount { get; set; }
    }
}