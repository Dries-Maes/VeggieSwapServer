using System.ComponentModel.DataAnnotations;

namespace VeggieSwapServer.Data.Entities
{
    public class Resource : EntityBase
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}