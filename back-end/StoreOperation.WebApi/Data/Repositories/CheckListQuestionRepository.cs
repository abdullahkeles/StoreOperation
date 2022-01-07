using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreOperation.WebApi.Data.Contexts;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;

namespace StoreOperation.WebApi.Data.Repositories
{
    public class CheckListQuestionRepository : Repository<CheckListQuestion>, ICheckListQuestionRepository
    {
        public CheckListQuestionRepository(StoreOperationDbContext storeOperationDb) : base(storeOperationDb)
        {
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var item = _storeOperationDb.CheckListQuestions.SingleOrDefault(x => x.CheckListQuestionId == id);
            item.State = false;
            var change = await _storeOperationDb.SaveChangesAsync();
            if (change == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveAllAsync(IEnumerable<Guid> ids)
        {
            try
            {
                CheckListQuestion item = null;
                bool result = true;
                foreach (Guid id in ids)
                {
                    item = null;
                    item = await _storeOperationDb.CheckListQuestions.SingleOrDefaultAsync(x =>
                        x.CheckListQuestionId == id);
                    item.State = false;
                    var change = await _storeOperationDb.SaveChangesAsync();
                    if (change != 1)
                    {
                        result = false;
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}