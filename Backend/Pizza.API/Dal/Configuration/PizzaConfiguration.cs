using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaEntity = Pizza.API.Domain.Entities.Pizza;

namespace Pizza.API.Dal.Configuration
{
    public class PizzaConfiguration : IEntityTypeConfiguration<PizzaEntity>
    {
        public void Configure(EntityTypeBuilder<PizzaEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Additives)
                .WithMany(x => x.Pizzas);

            builder.ComplexProperty(x => x.NutritionalValue);
        }
    }
}
