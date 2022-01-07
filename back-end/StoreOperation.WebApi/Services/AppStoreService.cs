using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.Configuration.Context;
using StoreOperation.WebApi.CustomEntities.Request.App;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;
using StoreOperation.WebApi.Services.Abstract;

namespace StoreOperation.WebApi.Services
{
    public class AppStoreService : BaseService, IAppStoreService
    {
        private readonly IAppStoreRepository _appStoreRepository;

        public AppStoreService(IMapper mapper, ILoggerRepository logger,
            IStoreOperationConfigurationContext configContext, IAppStoreRepository appStoreRepository) : base(mapper,
            logger, configContext)
        {
            _appStoreRepository = appStoreRepository;
        }

        public async Task<ApiResponse<IEnumerable<AppStore>>> GetAsync()
        {
            var data = await _appStoreRepository.GetAllAsync();
            return new SuccessApiResponse<IEnumerable<AppStore>>(ResponseStatus.Ok, data);
        }

        public async Task<ApiResponse<AppStore>> CreateAsync(CreateStore store)
        {
            var model = _mapper.Map<AppStore>(store);
            await _appStoreRepository.AddAsync(model);
            return new SuccessApiResponse<AppStore>(ResponseStatus.Created, model);
        }

        public async Task<ApiResponse<AppStore>> UpdateAsync(UpdateStore store)
        {
            var model = _mapper.Map<AppStore>(store);
            var result = await _appStoreRepository.UpdateAsync(model);
            return new SuccessApiResponse<AppStore>(ResponseStatus.Ok, result);
        }

        public async Task<ApiResponse> DeleteAsync(Guid storeId)
        {
            if (Guid.Empty == storeId)
            {
                return new ErrorApiResponse(ResultMessage.EmptyStoreId);
            }
            // var result = await _appStoreRepository.DeleteAsync(x => x.StoreId == storeId);
            var item = await _appStoreRepository.GetSingleAsync(x => x.StoreId == storeId);
            item.StoreState = false;
            var result = await _appStoreRepository.SaveASync();
            if (result > 0)
            {
                return new ApiResponse(ResponseStatus.Ok, ResultMessage.RemovedStore);
            }
            else
            {
                return new ApiResponse(ResponseStatus.Forbid,ResultMessage.NotRemovedStore);
            }
        }
    }
}