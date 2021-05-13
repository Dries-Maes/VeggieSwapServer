
namespace VeggieSwapServer.Business.Models
{
    public class TradeModel : ModelBase
    {
        public int UserId { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int PostalCode { get; set; }
    }
}
