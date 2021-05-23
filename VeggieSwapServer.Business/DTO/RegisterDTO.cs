using System.ComponentModel.DataAnnotations;

namespace VeggieSwapServer.Business.DTO
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(8)]
        public string Password { get; set; }

        [Required]
        [MinLength(1)]
        public string ImageUrl { get; set; }
    }
}