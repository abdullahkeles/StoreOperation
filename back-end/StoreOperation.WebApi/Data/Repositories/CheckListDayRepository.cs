using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.CustomEntities.Response.CheckListResponse;
using StoreOperation.WebApi.Data.Contexts;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;

namespace StoreOperation.WebApi.Data.Repositories
{
    public class CheckListDayRepository : Repository<CheckListDay>, ICheckListDayRepository
    {
        public CheckListDayRepository(StoreOperationDbContext checkedListDb) : base(checkedListDb)
        {
        }

        public async Task<IEnumerable<StoresInDayResponse>> GetStoresDay(DateTime day)
        {
            var dayStores = _storeOperationDb.CheckListDays
                .Include(i => i.CheckLists).ThenInclude(c => c.Questions)
                .Include(ii => ii.Store)
                .Where(x => x.Day == day && x.State)
                .Select(x => new StoresInDayResponse(x));
            return await dayStores.AsSplitQuery().ToArrayAsync();
        }

        public async Task<IEnumerable<CheckListDayGroupDto>> GetStoresDays(int record)
        {
            var days = await _storeOperationDb.CheckListDays
                .AsNoTracking().ToArrayAsync();
            var result = days.GroupBy(x => x.Day)
                .OrderByDescending(x => x.Key)
                .Take(record)
                .Select(s => new CheckListDayGroupDto() {Day = s.Key, CheckListDays = s.ToArray()})
                .ToArray();
            return result;
        }
    }
}