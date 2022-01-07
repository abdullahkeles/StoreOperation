using System.Threading.Tasks;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.CustomEntities.Request.UserRequest;
using StoreOperation.WebApi.CustomEntities.Response.AppResponse;

namespace StoreOperation.WebApi.Services.Abstract
{
    public interface IUserService
    {
        Task<ApiResponse<UserLoginResponse>> LoginAsync(UserLoginRequest request);
        Task<ApiResponse> RegisterAsync(RegisterUserRequest request);
        Task<ApiResponse> ChangePasswordAsync(UpdatePasswordRequest request);
        Task<ApiResponse> UpdateAsync(UpdateUserRequest request);
        Task<ApiResponse> RemindPasswordAsync(string email);
        Task<ApiResponse> RemindPasswordCompleteAsync(CompleteRemindPasswordRequest request);
        Task<ApiResponse> GetUserInfoAsync(string token);
        Task<ApiResponse> GetProfileImageAsync(string token);
    }
}
