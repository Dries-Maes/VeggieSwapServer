using System.Collections.Generic;

namespace VeggieSwapServer.Data.Entities
{
    public class Trade : EntityBase
    {
        public IEnumerable<TradeItem> TradeItems { get; set; }
        public List<Wallet> Wallets { get; set; }
    }
}