using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.CustomEntities.Request.CheckList;
using StoreOperation.WebApi.CustomEntities.Response.CheckListResponse;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.Services.Abstract
{
    public interface ICheckListService
    {
        Task<ApiResponse<CheckListDaysResponse>> GetCheckListDaysAsync(Guid StoreId);
        Task<ApiResponse<CheckListNewResponse>> NewCheckListAsync(Guid storeId);
        Task<ApiResponse> AddCheckListAsync(CheckListNewResponse checkList,Guid appUserId);
        Task<ApiResponse> AddCheckListQuestionGroupAsync(QuestionGroupCreateRequest model);
        Task<ApiResponse> UpdateCheckListQuestionGroupAsync(QuestionGroupUpdateRequest model);
        Task<ApiResponse<IEnumerable<CheckListQuestionGroupDto>>> GetCheckListQuestionGroupsAsync();
        Task<ApiResponse<IEnumerable<CheckListQuestion>>> GetCheckListQuestionAsync();
        /// <summary>
        /// soru grubuna ait soruları getirir.
        /// </summary>
        /// <param name="id">question group id</param>
        /// <returns></returns>
        Task<ApiResponse<IEnumerable<CheckListQuestion>>> GetCheckListQuestionInGroupAsync(Guid id);
        Task<ApiResponse<QuestionDto>> AddCheckListQuestionAsync(QuestionCreateRequest model);
        Task<ApiResponse> UpdateCheckListQuestionAsync(QuestionUpdateRequest model);
        Task<ApiResponse> RemoveCheckListQuestionAsync(Guid id);
        Task<ApiResponse> RemoveCheckListQuestionInGroupAsync(IEnumerable<Guid> ids);
    }
}