using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeggieSwapServer.Business.DTO
{
    public class TradeItemDetailDto
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceImageUrl { get; set; }
        public int Amount { get; set; }
    }
}