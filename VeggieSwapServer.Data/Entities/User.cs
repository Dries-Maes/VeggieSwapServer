using System.Collections.Generic;

namespace VeggieSwapServer.Data.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public Address Address { get; set; }

        public Wallet Wallet { get; set; }
        public List<Resource> AcceptedResources { get; set; }

        public List<TradeItem> TradeItems { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAdmin { get; set; }
    }
}