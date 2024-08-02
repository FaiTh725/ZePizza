using Microsoft.EntityFrameworkCore;
using Authentification.Domain.Entities;

namespace Authentification.API.Dal
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("NpgsConnection"));
        }
    }
}
