using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.Configuration.Context;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.CustomEntities.Response.CheckListResponse;
using StoreOperation.WebApi.Data.Repositories.Abstract;
using StoreOperation.WebApi.Services.Abstract;
using StoreOperation.WebApi.Utilities.Table.CheckLisDayViewTable;

namespace StoreOperation.WebApi.Services
{
    public class CheckListStoreReportService : BaseService, ICheckListStoreReportService
    {
        private readonly IAppStoreRepository _storeRepository;
        private readonly ICheckListDayRepository _dayRepository;
        private readonly ICheckListQuestionRepository _questionRepository;
        private readonly ICheckListQuestionAnswerRepository _questionAnswerRepository;

        public CheckListStoreReportService(IMapper mapper, ILoggerRepository logger,
            IStoreOperationConfigurationContext configContext, IAppStoreRepository storeRepository,
            ICheckListDayRepository dayRepository, ICheckListQuestionRepository questionRepository,
            ICheckListQuestionAnswerRepository questionAnswerRepository) : base(mapper, logger, configContext)
        {
            _storeRepository = storeRepository;
            _dayRepository = dayRepository;
            _questionRepository = questionRepository;
            _questionAnswerRepository = questionAnswerRepository;
        }

        public async Task<ApiResponse> GetStoreDayReport(Guid dayId)
        {
            if (dayId == Guid.Empty)
            {
                return new ErrorApiResponse("Raporun Id bilgisi boş olamaz.");
            }
            var dayGroupsInQuestions = await _questionAnswerRepository.GetStoreDayAnswers(dayId);

            var result = new CheckListDayReport();
            result.Groups = dayGroupsInQuestions.groups;
            result.Summaries = dayGroupsInQuestions.summary;

            return new SuccessApiResponse<CheckListDayReport>(result);
        }

        public Task<ApiResponse> GetStoreWeekReport(Guid storeId, string startDate, string finishDate)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetStoreMountReport(Guid storeId, int mount)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetStoreYearReport(Guid storeId, int year)
        {
            throw new NotImplementedException();
        }
    }
}