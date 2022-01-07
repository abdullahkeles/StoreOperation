using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOperation.WebApi.ActionFilters;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.CustomEntities.Request.CheckList;
using StoreOperation.WebApi.CustomEntities.Response.CheckListResponse;
using StoreOperation.WebApi.Helpers.Extensions;
using StoreOperation.WebApi.Services.Abstract;

namespace StoreOperation.WebApi.Controllers
{
    [ApiController]
    public class CheckListController : BaseController
    {
        private readonly ICheckListAppReportService _checkListAppReportService;
        private readonly ICheckListService _checkListDayService;
        private readonly ICheckListStoreReportService _checkListReportService;

        public CheckListController(ICheckListAppReportService checkListAppReportService,ICheckListService checkListDayService,ICheckListStoreReportService checkListReportService)
        {
            _checkListAppReportService = checkListAppReportService;
            _checkListDayService = checkListDayService;
            _checkListReportService = checkListReportService;
        }
        
        [Route("/check-list/days")]
        [HttpGet]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse<CheckListDaysResponse>> GetCheckListDays()
        {
            var StoreId = User.Claims.GetUserStoreId();
            var UserId = User.Claims.GetUserId();
            return await _checkListDayService.GetCheckListDaysAsync(StoreId);
        }
        [Route("/check-list/question-groups")]
        [HttpGet]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse<IEnumerable<CheckListQuestionGroupDto>>> GetCheckListQuestionGroups()
        {
            return await _checkListDayService.GetCheckListQuestionGroupsAsync();
        }
        [Route("/check-list/question-group-create")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse> AddCheckListQuestionGroup(QuestionGroupCreateRequest model)
        {
            return await _checkListDayService.AddCheckListQuestionGroupAsync(model);
        } 
        [Route("/check-list/create")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse> CheckListCreate()
        {
            var StoreId = User.Claims.GetUserStoreId();
            return await _checkListDayService.NewCheckListAsync(StoreId);
        }
        [Route("/check-list/add")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse> CheckListAdd(CheckListNewResponse checkListNew)
        {
            var userId = User.Claims.GetUserId();
            return await _checkListDayService.AddCheckListAsync(checkListNew,userId);
        }
        [Route("/check-list/question-group-update")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse> UpdateCheckListQuestionGroup(QuestionGroupUpdateRequest model)
        {
            return await _checkListDayService.UpdateCheckListQuestionGroupAsync(model);
        }
        
        [Route("/check-list/question-create")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse> AddCheckListQuestion(QuestionCreateRequest model)
        {
            return await _checkListDayService.AddCheckListQuestionAsync(model);
        }

        [Route("/check-list/question-update")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse> UpdateCheckListQuestion(QuestionUpdateRequest model)
        {
            return await _checkListDayService.UpdateCheckListQuestionAsync(model);
        }
        
        [Route("/check-list/question-get-all")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse> GetAllCheckListQuestion()
        {
            return await _checkListDayService.GetCheckListQuestionAsync();
        }
        
        [Route("/check-list/questions-in-group-get-all")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse> GetAllCheckListQuestionInGroup(QuestionsInGroupGetRequest model)
        {
            return await _checkListDayService.GetCheckListQuestionInGroupAsync(model.checkListQuestionGroupId);
        }
        
        [Route("/check-list/questions-remove")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse> RemoveCheckListQuestion(Guid guid)
        {
            return await _checkListDayService.RemoveCheckListQuestionAsync(guid);
        }
        
        [Route("/check-list/questions-in-group-remove")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<ApiResponse> RemoveCheckListQuestionInGroup(Guid guid)
        {
            return await _checkListDayService.RemoveCheckListQuestionAsync(guid);
        }
        
        [HttpGet]
        [Route("/check-list/store-report-day")]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<IActionResult> _GetStoreDayReport(Guid dayId)
        {
            var result = await _checkListReportService.GetStoreDayReport(dayId);
            return ApiResponse(result);
        }
        
        [HttpGet]
        [Route("/check-list/app-days-stores-report")]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<IActionResult> GetLastTenDaysStoresReport()
        {
            var result = await _checkListAppReportService.GetStoresDaysReport(10);
            return ApiResponse(result);
        }
        [HttpGet]
        [Route("/check-list/app-day-stores-report")]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<IActionResult> GetDayStoresReport(string day)
        {
            var result = await _checkListAppReportService.GetStoresDayReport(day);
            return ApiResponse(result);
        }
    }
}