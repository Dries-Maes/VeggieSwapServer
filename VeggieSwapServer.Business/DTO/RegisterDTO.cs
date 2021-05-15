
using System.ComponentModel.DataAnnotations;


namespace VeggieSwapServer.Business.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(8)]
        public string Password { get; set; }
    }
}
