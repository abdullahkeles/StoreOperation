using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreOperation.WebApi.Data.Entities.Mappings
{
    public class AppStoreMapping : IEntityTypeConfiguration<AppStore>
    {
        public void Configure(EntityTypeBuilder<AppStore> builder)
        {
            builder.HasKey(x => x.StoreId);
            builder.HasIndex(x => x.StoreId).HasFillFactor(80);
            builder.Property(x => x.VergiKimlikNo).HasMaxLength(10);
            //     builder
            //         .HasOne(x => x.Manager)
            //         .WithOne()
            //         .HasForeignKey<ShopeStore>(x => x.ManagerId); 
            //     builder
            //         .HasOne(x => x.ProxyManager)
            //         .WithOne()
            //         .HasForeignKey<ShopeStore>(x => x.ProxyManagerId);
            //     builder
            //         .HasMany(p => p.AsistanManagers)
            //         .WithMany(x => x.ShopeStores)
            //         .UsingEntity(j => j.ToTable("PostTags"));
            //     builder
            //         .HasMany(p => p.AsistanManagers)
            //         .WithMany(x => x.ShopeStores)
            //         .UsingEntity(j => j.ToTable("PostTags"));
        }
    }
}