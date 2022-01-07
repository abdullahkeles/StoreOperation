using StoreOperation.WebApi.Data.Contexts;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;

namespace StoreOperation.WebApi.Data.Repositories
{
    public class AppStoreRepository:Repository<AppStore>,IAppStoreRepository
    {
        public AppStoreRepository(StoreOperationDbContext checkedListDb) : base(checkedListDb)
        {
        }
    }
}