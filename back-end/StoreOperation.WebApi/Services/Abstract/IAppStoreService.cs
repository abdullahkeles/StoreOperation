using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.CustomEntities.Request.App;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.Services.Abstract
{
    public interface IAppStoreService
    {
        Task<ApiResponse<IEnumerable<AppStore>>> GetAsync();
        Task<ApiResponse<AppStore>> CreateAsync(CreateStore store);
        Task<ApiResponse<AppStore>> UpdateAsync(UpdateStore store);
        Task<ApiResponse> DeleteAsync(Guid storeId);
    }
}