namespace VeggieSwapServer.Business.DTO
{
    public class TradeItemDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceImageUrl { get; set; }
        public int Amount { get; set; }
        public int ProposedAmount { get; set; }
        public int ActiveUserId { get; set; }
    }
}