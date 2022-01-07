using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreOperation.WebApi.Common.DataAccess;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.CustomEntities.Response.CheckListResponse;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.Data.Repositories.Abstract
{
    public interface ICheckListQuestionAnswerRepository:IRepository<CheckListQuestionAnswer>
    {
        Task<(IEnumerable<CheckListDayReportList> summary, IEnumerable<CheckListDayReportGroup> groups)> GetStoreDayAnswers(Guid dayId);
    }
}