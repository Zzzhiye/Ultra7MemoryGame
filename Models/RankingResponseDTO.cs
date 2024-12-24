namespace MemoryGame.Models
{
    public class RankingResponseDTO
    {
        public long ActivityId { get; set; }
        public string UserName { get; set; }
        public TimeSpan CompletionTime { get; set; }
        public DateTime DateTime { get; set; }
    }
}
