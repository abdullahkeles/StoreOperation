using AutoMapper;
using StoreOperation.WebApi.Configuration.Context;
using StoreOperation.WebApi.Data.Repositories.Abstract;

namespace StoreOperation.WebApi.Services
{
    public class BaseService
    {
        protected IMapper _mapper;
        protected ILoggerRepository _logger;
        protected IStoreOperationConfigurationContext _configContext;
        public BaseService(
            IMapper mapper,
            ILoggerRepository logger, IStoreOperationConfigurationContext configContext)
        {
            _mapper = mapper;
            _logger = logger;
            _configContext = configContext;
        }
    }
}
