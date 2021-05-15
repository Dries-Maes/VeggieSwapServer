using System;

namespace VeggieSwapServer.Business.Models
{
    public class ModelBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}