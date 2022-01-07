using System;
using System.Threading.Tasks;
using StoreOperation.WebApi.Common.Api;

namespace StoreOperation.WebApi.Services.Abstract
{
    /// <summary>
    /// bu servis uygulama seviyesinde
    /// bütün mağazaların raporlarını döndürür
    /// </summary>
    public interface ICheckListAppReportService
    {
        /// <summary>
        /// günlük firmanın bütün mağaza bilgilerini getirir.
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        Task<ApiResponse> GetStoresDayReport(string day); 
        
        /// <summary>
        /// günlük firmanın bütün mağaza bilgilerini getirir.
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        Task<ApiResponse> GetStoresDaysReport(int record);
        
        
        /// <summary>
        /// günlük sadece secilen mağazanın bilgilerini döndürür
        /// </summary>
        /// <param name="dayId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        Task<ApiResponse> GetStoreDayReport(Guid dayId,Guid storeId);
        /// <summary>
        /// bir mağazanın haftalık raporunu döndürür
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        /// <returns></returns>
        Task<ApiResponse> GetStoreWeekReport(Guid storeId,string startDate,string finishDate);
        /// <summary>
        /// bir mağazanın aylık raporunu döndürür
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="mount"></param>
        /// <returns></returns>
        Task<ApiResponse> GetStoreMountReport(Guid storeId,int mount);
        /// <summary>
        /// bir mağazanın yıllık raporunu döndürür
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        Task<ApiResponse> GetStoreYearReport(Guid storeId,int year);
    }
}