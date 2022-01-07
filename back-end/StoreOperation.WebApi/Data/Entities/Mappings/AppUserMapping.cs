using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreOperation.WebApi.Data.Entities.Mappings
{
    public class AppUserMapping : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasMany(x => x.RelationStoreUsers)
                .WithOne(y => y.User);

            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => x.UserId).HasFillFactor(80);
            builder.HasIndex(x => x.Email).IsUnique().HasFillFactor(80);
            builder.HasIndex(x => x.UserName).IsUnique().HasFillFactor(80);

            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Email).IsRequired();


            builder.Property(x => x.Email).HasMaxLength(255);
            builder.Property(x => x.Name).HasMaxLength(150);
            builder.Property(x => x.SurName).HasMaxLength(150);
            builder.Property(x => x.MobilePhone).HasMaxLength(10);
            builder.Property(x => x.OfficePhone).HasMaxLength(150);
            builder.Property(x => x.OfficePhone).HasMaxLength(150);
        }
    }
}