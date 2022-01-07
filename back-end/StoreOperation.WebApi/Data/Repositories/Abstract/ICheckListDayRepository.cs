using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.Common.DataAccess;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.CustomEntities.Response.CheckListResponse;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.Data.Repositories.Abstract
{
    public interface ICheckListDayRepository:IRepository<CheckListDay>
    {
        /// <summary>
        /// ilgili günün bilgi girişi yapılan mağazalarının bilgileri
        /// geri döndürür
        /// </summary>
        /// <param name="day">bilgisi istenen günün bilgisi</param>
        /// <returns></returns>
        Task<IEnumerable<StoresInDayResponse>> GetStoresDay(DateTime day);
        Task<IEnumerable<CheckListDayGroupDto>> GetStoresDays(int record);
    }
}