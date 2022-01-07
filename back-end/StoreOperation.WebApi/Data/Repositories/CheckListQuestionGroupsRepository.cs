using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.Data.Contexts;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;

namespace StoreOperation.WebApi.Data.Repositories
{
    public class CheckListQuestionGroupsRepository : Repository<CheckListQuestionGroup>,
        ICheckListQuestionGroupsRepository
    {
        public CheckListQuestionGroupsRepository(StoreOperationDbContext checkedListDb) : base(checkedListDb)
        {
        }

        public async Task<IEnumerable<CheckListQuestionGroupDto>> GetInQuestionAllAsync()
        {
            var groups = await _storeOperationDb.CheckListQuestionGroups
                .Include(x => x.CheckListQuestions)
                .OrderBy(x => x.Sort)
                .Select(x =>
                    new CheckListQuestionGroupDto(
                        x.CheckListQuestionGroupId,
                        x.Name,
                        x.State,
                        x.Sort,
                        x.CheckListQuestions.Where(y => y.State).Sum(c => c.Skor)
                    ))
                .AsNoTracking()
                .ToArrayAsync();
            return groups;
        }
    }
}