using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeggieSwapServer.Data.Entities
{
    public class Trade : EntityBase
    {
        public IEnumerable<TradeItem> TradeItems { get; set; }
    }
}