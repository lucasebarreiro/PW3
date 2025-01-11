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
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);

            });


            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.Id);


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
                entity.HasKey(w => w.Id);

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

