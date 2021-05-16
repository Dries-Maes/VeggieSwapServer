using System.ComponentModel.DataAnnotations;

namespace VeggieSwapServer.Data.Entities
{
    public class Resource : EntityBase
    {
        [StringLength(20)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}