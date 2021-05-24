﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;

namespace VeggieSwapServer.Business.DTO
{
    public class TradeDto
    {
        public int Id { get; set; }
        public UserDto Proposer { get; set; }
        public UserDto Receiver { get; set; }

        public ICollection<TradeItemDto> TradeItemProposals { get; set; }
        public bool Completed { get; set; }

        public int ActiveUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}