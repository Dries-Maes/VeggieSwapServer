using System;
using System.Collections.Generic;
using VeggieSwapServer.Business.Models;

namespace VeggieSwapServer.Business.DTO
{
    public class TradeDto
    {
        public int Id { get; set; }

        public UserDto User { get; set; }

        public ICollection<TradeItemDto> TradeItemProposals { get; set; }
        public bool Completed { get; set; }

        public int ActiveUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}