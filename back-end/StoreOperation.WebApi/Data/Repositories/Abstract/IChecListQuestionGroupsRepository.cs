using System.Collections.Generic;
using System.Threading.Tasks;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.Common.DataAccess;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.Data.Repositories.Abstract
{
    public interface ICheckListQuestionGroupsRepository :IRepository<CheckListQuestionGroup>
    {
        Task<IEnumerable<CheckListQuestionGroupDto>> GetInQuestionAllAsync();
    }
}