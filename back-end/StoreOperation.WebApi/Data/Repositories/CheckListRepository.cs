using StoreOperation.WebApi.Data.Contexts;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;

namespace StoreOperation.WebApi.Data.Repositories
{
    public class CheckListRepository:Repository<CheckList>,ICheckListRepository
    {
        public CheckListRepository(StoreOperationDbContext storeOperationDb) : base(storeOperationDb)
        {
        }
    }
}