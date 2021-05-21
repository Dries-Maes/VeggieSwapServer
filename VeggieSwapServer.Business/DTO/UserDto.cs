using System;

namespace VeggieSwapServer.Business.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AddressID { get; set; }
        public int AddressPostalCode { get; set; }
        public string AddressStreetName { get; set; }
        public int AddressStreetNumber { get; set; }
        public int WalletID { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAdmin { get; set; }
    }
}