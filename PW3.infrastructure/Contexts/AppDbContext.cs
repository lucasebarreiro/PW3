using Microsoft.EntityFrameworkCore;
using PW3.Domain.Models;

namespace PW3.infrastructure.Contexts
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameWord> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);

            });


            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(g => g.Usuario1)
                    .WithMany()
                    .HasForeignKey(g => g.Usuario1Id)
                    .OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada


                entity.HasOne(g => g.Usuario2)
                    .WithMany()
                    .HasForeignKey(g => g.Usuario2Id)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(g => g.FechaInicio)
                    .IsRequired();

                entity.Property(g => g.DuracionEnSegundos)
                    .IsRequired();
            });


            modelBuilder.Entity<GameWord>(entity =>
            {
                entity.Property(w => w.Word)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(w => w.Game)
                    .WithMany(g => g.Words)
                    .HasForeignKey(w => w.GameId);
            });
        }
    }
}

