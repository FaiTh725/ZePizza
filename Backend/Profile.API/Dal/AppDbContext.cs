using Microsoft.EntityFrameworkCore;
using Profile.API.Dal.Configurations;
using Profile.Domain.Entities;
using ProfileEntity = Profile.Domain.Entities.Profile;

namespace Profile.API.Dal
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<ProfileEntity> Profiles { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("NpgsConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
