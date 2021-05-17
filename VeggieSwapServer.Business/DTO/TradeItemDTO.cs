using System.Collections.Generic;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.DTO
{
    public class TradeItemDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }        
        public Resource Resource { get; set; }
        public int Amount { get; set; }
    }
}