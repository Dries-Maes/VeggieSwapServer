using System.Collections.Generic;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.DTO
{
    public class TradeItemDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Resource> AcceptedResources { get; set; }
        public Resource Resource { get; set; }
        public int Amount { get; set; }
    }
}