using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreOperation.WebApi.Data.Entities.Mappings
{
    public class AppLogMapping : IEntityTypeConfiguration<AppLog>
    {
        public void Configure(EntityTypeBuilder<AppLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).HasFillFactor(80);
        }
    }
}