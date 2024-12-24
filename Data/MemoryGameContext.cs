using Microsoft.EntityFrameworkCore;
using MemoryGame.Models;

namespace MemoryGame.Data
{
    public class MemoryGameContext : DbContext
    {
        public MemoryGameContext(DbContextOptions<MemoryGameContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Ranking> Rankings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.IsPaid).HasDefaultValue(false);
            });

            // Configure Ranking entity
            modelBuilder.Entity<Ranking>(entity =>
            {
                entity.HasKey(e => e.ActivityId);
                // Relationship with User
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(r => r.UserId)
                    .HasPrincipalKey(u => u.UserId);
            });
        }
    }
}