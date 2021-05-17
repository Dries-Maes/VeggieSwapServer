﻿using System.Collections.Generic;

namespace VeggieSwapServer.Data.Entities
{
    public class Trade : EntityBase
    {
        public virtual ICollection<TradeItem> TradeItems { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}