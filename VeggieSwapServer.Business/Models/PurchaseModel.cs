using System;

namespace VeggieSwapServer.Business.Models
{
    public class PurchaseModel : ModelBase
    {
        public DateTime DateTime { get; set; }
        public decimal VAmount { get; set; }
        public decimal EuroAmount { get; set; }
    }
}