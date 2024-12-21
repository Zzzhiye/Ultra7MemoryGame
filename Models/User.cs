using System.ComponentModel.DataAnnotations;
namespace MemoryGame.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required String Password { get; set; }
        public String? Email { get; set; }
        public Boolean IsPaid { get; set; } = false;
    }
}