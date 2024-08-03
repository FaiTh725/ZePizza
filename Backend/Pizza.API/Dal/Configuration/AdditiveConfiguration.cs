using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.API.Domain.Entities;

namespace Pizza.API.Dal.Configuration
{
    public class AdditiveConfiguration : IEntityTypeConfiguration<Additive>
    {
        public void Configure(EntityTypeBuilder<Additive> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Pizzas)
                .WithMany(x => x.Additives);
        }
    }
}
