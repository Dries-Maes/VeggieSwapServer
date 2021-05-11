using System.Collections.Generic;

namespace VeggieSwapServer.Data.Entities
{
    public class Trade
    {
        public int Id { get; set; }
        public List<TradeItem> TradeItems { get; set; }
    }
}