using System;
using System.Collections.Generic;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public Wallet Wallet { get; set; }
        public List<TradeItem> TradeItems { get; set; }

        public string ImageUrl { get; set; }
        public bool IsAdmin { get; set; }
    }
}