using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreOperation.WebApi.Data.Entities.Mappings
{
    public class AppRoleMapping:IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(x => x.RoleId);
            builder.HasIndex(x => x.RoleId).HasFillFactor(80);
        }
    }
}