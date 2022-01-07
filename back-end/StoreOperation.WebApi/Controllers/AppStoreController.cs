using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOperation.WebApi.ActionFilters;
using StoreOperation.WebApi.CustomEntities.Request.App;
using StoreOperation.WebApi.Services.Abstract;

namespace StoreOperation.WebApi.Controllers
{
    [ApiController]
    public class AppStoreController : BaseController
    {
        private readonly IAppStoreService _appStoreService;

        public AppStoreController(IAppStoreService appStoreService)
        {
            _appStoreService = appStoreService;
        }
        
        [Route("/app-store/get-all")]
        [HttpGet]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<IActionResult> GetStores()
        {
            var result = await _appStoreService.GetAsync();
            return ApiResponse(result);
        }
        
        [Route("/app-store/create")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<IActionResult> AddStore([FromBody]CreateStore store)
        {
            var result = await _appStoreService.CreateAsync(store);
            return ApiResponse(result);
        }
        [Route("/app-store/update")]
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<IActionResult> UpdateStore([FromBody]UpdateStore store)
        {
            var result = await _appStoreService.UpdateAsync(store);
            return ApiResponse(result);
        }
    }
}