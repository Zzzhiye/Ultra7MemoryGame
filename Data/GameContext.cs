using Microsoft.EntityFrameworkCore;
using MemoryGame.Models;

namespace MemoryGame.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Ranking> Rankings { get; set; }

        public DbSet<Ranking> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Ranking>().ToTable("ranking");
        }
    }

}
