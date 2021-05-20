using System;
using System.Collections.Generic;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.DTO
{
    public class TradeItemOverviewDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceImageUrl { get; set; }
        public int Amount { get; set; }
        public int ProposedAmount { get; set; }
    }
}