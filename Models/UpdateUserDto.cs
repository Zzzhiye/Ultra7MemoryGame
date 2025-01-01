using System.ComponentModel.DataAnnotations;

namespace MemoryGame.Models
{
    public class UpdateUserDto
    {
        [Required]
        [StringLength(50)]
        public required string UserName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
