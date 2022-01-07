using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.CustomEntities.Response.CheckListResponse;
using StoreOperation.WebApi.Data.Contexts;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;

namespace StoreOperation.WebApi.Data.Repositories
{
    public class CheckListQuestionAnswerRepository : Repository<CheckListQuestionAnswer>,
        ICheckListQuestionAnswerRepository
    {
        public CheckListQuestionAnswerRepository(StoreOperationDbContext storeOperationDb) : base(storeOperationDb)
        {
        }

        public async Task<(IEnumerable<CheckListDayReportList>,IEnumerable<CheckListDayReportGroup>)> GetStoreDayAnswers(Guid dayId)
        {
            var questions = await _storeOperationDb.CheckListQuestionAnswers
                .Include(x => x.CheckListQuestion)
                .Include(x => x.CheckList)
                .Where(x => x.CheckList.CheckListDayId == dayId)
                .AsNoTracking()
                .ToArrayAsync();

            var summary = from q in questions
                group q by q.CheckListId
                into g
                select new CheckListDayReportList(g.Key, g.First().CheckList.Rank, g.Count(x => x.Answer),
                    g.Count(x => !x.Answer), g.First().CheckList.TimeSpan);
            
            var uniqQuestions = questions.GroupBy(v => v.CheckListQuestionId)
                .Select(x => new CheckListAnswersToQuestionDto(x.Key, x.First().CheckListQuestion.Question,
                    x.ToArray().First().CheckListQuestion.CheckListQuestionGroupId,
                    x.Select(z => new CheckListQuestionAnswerDto(z.Answer, z.AnswerState, z.Skor, z.CheckListId))))
                .ToArray();

            var groups = from q in uniqQuestions
                group q by q.GroupId
                into g
                join gGroup in _storeOperationDb.CheckListQuestionGroups on g.Key equals gGroup.CheckListQuestionGroupId
                select new CheckListDayReportGroup(gGroup.Name, g.Key, g);

            return (summary,groups);
        }
    }
}