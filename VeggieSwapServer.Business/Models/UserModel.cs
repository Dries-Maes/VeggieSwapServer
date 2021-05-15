using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.Models
{
    public class UserModel : ModelBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string  Email { get; set; }

        public Address Address { get; set; }

        public Wallet Wallet { get; set; }

        public string ImageUrl { get; set; }
        public bool IsAdmin { get; set; }
    }
}