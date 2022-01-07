using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.Configuration.Context;
using StoreOperation.WebApi.CustomEntities.Response;
using StoreOperation.WebApi.CustomEntities.Response.CheckListResponse;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;
using StoreOperation.WebApi.Services.Abstract;

namespace StoreOperation.WebApi.Services
{
    public class CheckListAppReportService : BaseService, ICheckListAppReportService
    {
        private readonly ICheckListDayRepository _checkListDayRepository;

        public CheckListAppReportService(ICheckListDayRepository checkListDayRepository, IMapper mapper,
            ILoggerRepository logger, IStoreOperationConfigurationContext configContext) : base(mapper, logger,
            configContext)
        {
            _checkListDayRepository = checkListDayRepository;
        }

        public async Task<ApiResponse> GetStoresDayReport(string day)
        {
            if (string.IsNullOrEmpty(day))
            {
                return new ErrorApiResponse("Günlük Kontrol Listesi -> tarih bilgisi yok.");
            }

            DateTime dateValue;

            if (!DateTime.TryParse(day, out dateValue))
            {
                return new ErrorApiResponse("Günlük Kontrol Listesi -> tarih formatı uyumsuz.");
            }

            var dayStores = await _checkListDayRepository.GetStoresDay(dateValue);
            
            return new SuccessApiResponse<IEnumerable<StoresInDayResponse>>(ResponseStatus.Ok, dayStores);
        }

        public async Task<ApiResponse> GetStoresDaysReport(int record)
        {
            var daysStores = await _checkListDayRepository.GetStoresDays(record);
            var result = daysStores.Select(x => new StoresInDaysItemResponse(x)).ToArray();
            return new SuccessApiResponse<StoresInDaysItemResponse[]>(ResponseStatus.Ok, result);
        }

        public Task<ApiResponse> GetStoreDayReport(Guid dayId, Guid storeId)
        {
            throw new NotImplementedException();
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