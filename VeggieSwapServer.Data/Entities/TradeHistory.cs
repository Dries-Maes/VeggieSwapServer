using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeggieSwapServer.Data.Entities
{
    internal class TradeHistory : EntityBase
    {
        public string TradeItemsJSon { get; set; }

        public int ProposerId { get; set; }

        public int ReceiverId { get; set; }
    }
}