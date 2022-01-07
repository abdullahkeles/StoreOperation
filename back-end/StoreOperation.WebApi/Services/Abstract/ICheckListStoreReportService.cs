using System;
using System.Threading.Tasks;
using StoreOperation.WebApi.Common.Api;

namespace StoreOperation.WebApi.Services.Abstract
{
    public interface ICheckListStoreReportService
    {
        /// <summary>
        /// secilen günün bilgilerini döndürür
        /// </summary>
        /// <param name="dayId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        Task<ApiResponse> GetStoreDayReport(Guid dayId);
        Task<ApiResponse> GetStoreWeekReport(Guid storeId,string startDate,string finishDate);
        Task<ApiResponse> GetStoreMountReport(Guid storeId,int mount);
        Task<ApiResponse> GetStoreYearReport(Guid storeId,int year);
    }
}