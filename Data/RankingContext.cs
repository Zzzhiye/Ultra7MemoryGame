using MemoryGame.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Data
{
    public class RankingContext : DbContext
    {
        public RankingContext(DbContextOptions<RankingContext> options) : base(options) { }
        public DbSet<Ranking> Rankings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ranking>().ToTable("ranking");
        }
    }
}
