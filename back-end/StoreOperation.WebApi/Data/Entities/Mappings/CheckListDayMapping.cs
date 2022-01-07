using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreOperation.WebApi.Data.Entities.Mappings
{
    public class CheckListDayMapping : IEntityTypeConfiguration<CheckListDay>
    {
        public void Configure(EntityTypeBuilder<CheckListDay> builder)
        {
            // indexin %20 boş olması ile yeni gelen kayıtların indexi bozmasını 
            // belirli birmiktar engellemiş oluruz.
            builder.HasIndex(x => new {x.StoreId, x.Day}).HasFillFactor(80);
            builder.HasIndex(x => new {x.StoreId}).HasFillFactor(80);
            builder.Property(x => x.Day).HasColumnType("date");

        }
    }
}