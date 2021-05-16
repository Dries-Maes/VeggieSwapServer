using System.ComponentModel.DataAnnotations;

namespace VeggieSwapServer.Data.Entities
{
    public class Address : EntityBase
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string StreetName { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        public int PostalCode { get; set; }
    }
}