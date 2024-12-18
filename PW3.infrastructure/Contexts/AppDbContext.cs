using Microsoft.EntityFrameworkCore;
using PW3.Domain.Models;

namespace PW3.infrastructure.Contexts
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Score> Scores { get; set; }





    }
}

