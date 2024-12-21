using System.ComponentModel.DataAnnotations;

namespace MemoryGame.Models
{
    public class Ranking
    {
        [Key]
        public int ActivityId { get; set; }
        public required String UserName { get; set; }
        public required int completionTime { get; set; }
        public required DateTime DateTime { get; set; }
    }
}
