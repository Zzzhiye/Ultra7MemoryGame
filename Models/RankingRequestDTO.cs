namespace MemoryGame.Models
{
    public class RankingRequestDTO
    {
        public long UserId { get; set; }
        public TimeSpan CompletionTime { get; set; }
    }
}
