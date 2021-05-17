using System;
using System.Collections.Generic;
using VeggieSwapServer.Business.DTO;
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
        public int AddressID { get; set; }
        public string AddressStreetName { get; set; }
        public string AddressPostalCode { get; set; }
        public int WalletID { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAdmin { get; set; }
    }
}