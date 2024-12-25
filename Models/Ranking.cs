using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryGame.Models
{
    [Table("Ranking")]
    public class Ranking
    {
        [Key]
        public long ActivityId { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public TimeSpan CompletionTime { get; set; }  // Time in seconds

        [Required]
        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
