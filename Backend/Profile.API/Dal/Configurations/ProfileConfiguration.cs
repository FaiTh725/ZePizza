using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfileEntity = Profile.Domain.Entities.Profile;

namespace Profile.API.Dal.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Profile)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
