namespace VeggieSwapServer.Data.Entities
{
    internal class TradeHistory : EntityBase
    {
        public string TradeItemsJSon { get; set; }

        public int ProposerId { get; set; }

        public int ReceiverId { get; set; }
    }
}