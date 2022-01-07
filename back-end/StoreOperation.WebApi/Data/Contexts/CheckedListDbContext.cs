using Microsoft.EntityFrameworkCore;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Entities.Mappings;

namespace StoreOperation.WebApi.Data.Contexts
{
    public class StoreOperationDbContext:DbContext
    {
        public StoreOperationDbContext(DbContextOptions<StoreOperationDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMapping());
            modelBuilder.ApplyConfiguration(new AppStoreMapping());
            modelBuilder.ApplyConfiguration(new AppRoleMapping());
            modelBuilder.ApplyConfiguration(new AppLogMapping());
            modelBuilder.ApplyConfiguration(new CheckListDayMapping());
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<AppStore> AppStores { get; set; }
        public virtual DbSet<AppLog> AppLogs { get; set; }
        
        public virtual DbSet<AppUserAppStore> AppUsersAppStores { get; set; }

        
        public virtual DbSet<CheckList> CheckLists { get; set; }
        public virtual DbSet<CheckListDay> CheckListDays { get; set; }
        public virtual DbSet<CheckListQuestion> CheckListQuestions { get; set; }
        public virtual DbSet<CheckListQuestionAnswer> CheckListQuestionAnswers { get; set; }
        public virtual DbSet<CheckListQuestionGroup> CheckListQuestionGroups { get; set; }
        
    }
}