using System;

namespace VeggieSwapServer.Data.Entities
{
    public class Purchase : EntityBase
    {
        public DateTime DateTime { get; set; }
        public decimal VAmount { get; set; }
        public decimal EuroAmount { get; set; }
    }
}