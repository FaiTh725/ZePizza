using Microsoft.EntityFrameworkCore;
using Pizza.API.Dal.Configuration;
using Pizza.API.Domain.Entities;
using PizzaEntity = Pizza.API.Domain.Entities.Pizza;

namespace Pizza.API.Dal
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<PizzaEntity> Pizzas { get; set; }

        public DbSet<Additive> Additives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("NpgsqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdditiveConfiguration());
            modelBuilder.ApplyConfiguration(new PizzaConfiguration());
        }
    }
}
