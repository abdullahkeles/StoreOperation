using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using StoreOperation.WebApi.Helpers.Extensions;
using Microsoft.AspNetCore.Mvc;
using StoreOperation.WebApi.ActionFilters;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.CustomEntities.Request.UserRequest;
using StoreOperation.WebApi.Services.Abstract;
using StoreOperation.WebApi.Utilities.File;

namespace StoreOperation.WebApi.Controllers
{
    [ValidateModelState]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IWebHostEnvironment _environment;

        public UserController(IUserService userService,IWebHostEnvironment environment)
        {
            this.userService = userService;
            _environment = environment;
        }

        [HttpPost]
        [Route("/users/login")]
        public async Task<IActionResult> Login(UserLoginRequest model)
        {
            
            var result= await userService.LoginAsync(model);
            return ApiResponse(result);
        }
        
        [HttpPost]
        [ServiceFilter(typeof(TokenAuthentication))]
        [Route("/users/info")]
        public async Task<IActionResult> Info(string id)
        {
            var result = await userService.GetUserInfoAsync(id);
            return ApiResponse(result);
        }

        [HttpPost]
        [Route("/users/register")]
        //todo developmentdan sonra [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<IActionResult> Register([FromForm] RegisterUserRequest request)
        {
            var result = await userService.RegisterAsync(request);

            return ApiResponse(result);
        }

        [HttpPost]
        [Route("/users/change-password")]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<IActionResult> ChangePassword([FromBody] UpdatePasswordRequest request)
        {
            request.UserId = User.Claims.GetUserId();

            var result = await userService.ChangePasswordAsync(request);

            return ApiResponse(result);
        }

        [HttpPatch]
        [Route("/users/update")]
        [ServiceFilter(typeof(TokenAuthentication))]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserRequest request)
        {
            request.UserId = User.Claims.GetUserId();

            var result = await userService.UpdateAsync(request);

            return ApiResponse(result);
        }

        [Route("/users/{email}/remind-password")]
        [HttpGet]
        public async Task<IActionResult> RemindPassword([FromRoute] string email)
        {
            var result = await userService.RemindPasswordAsync(email);

            return ApiResponse(result);
        }

        [Route("/users/profile-image")]
        [HttpPost]
        public async Task<IActionResult> GetProfileImage(string token)
        {
            var result = await userService.GetProfileImageAsync(token);
            return ApiResponse(result);
        }

        [HttpPost]
        [Route("/users/me/remind-password-complete")]
        public async Task<IActionResult> RemindPasswordCompleteAsync(CompleteRemindPasswordRequest request)
        {
            var result = await userService.RemindPasswordCompleteAsync(request);
            return ApiResponse(result);
        }
        
        
    }
}