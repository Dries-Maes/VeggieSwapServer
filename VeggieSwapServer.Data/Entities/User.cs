namespace VeggieSwapServer.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        public Wallet Wallet { get; set; }

        public string ImageUrl { get; set; }
        public bool IsAdmin { get; set; }
    }
}