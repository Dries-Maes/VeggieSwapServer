namespace VeggieSwapServer.Data.Entities
{
    public class Address : EntityBase
    {
        public int UserId { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int PostalCode { get; set; }
    }
}