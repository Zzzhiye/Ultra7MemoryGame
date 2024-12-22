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
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        public int CompletionTime { get; set; }  // Time in seconds

        [Required]
        public DateTime DateTime { get; set; }
        
        [ForeignKey("UserName")]
        public virtual User User { get; set; }
    }
}
