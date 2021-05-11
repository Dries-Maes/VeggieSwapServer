using System;

namespace VeggieSwapServer.Data.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal VAmount { get; set; }
        public decimal EuroAmount { get; set; }
    }
}