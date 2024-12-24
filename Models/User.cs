using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryGame.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public long UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        public bool IsPaid { get; set; } = false;

    }
}