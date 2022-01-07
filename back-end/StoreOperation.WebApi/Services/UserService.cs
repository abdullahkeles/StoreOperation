using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.Common.Enums;
using StoreOperation.WebApi.Configuration.Context;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.CustomEntities.Request.UserRequest;
using StoreOperation.WebApi.CustomEntities.Response.AppResponse;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;
using StoreOperation.WebApi.Helpers.Extensions;
using StoreOperation.WebApi.Services.Abstract;
using StoreOperation.WebApi.Utilities.Email;
using StoreOperation.WebApi.Utilities.File;
using StoreOperation.WebApi.Utilities.Security.Hash;
using StoreOperation.WebApi.Utilities.Security.Token;

namespace StoreOperation.WebApi.Services
{
    //TODO: Aynı username ile kayıt yapılabiliyor

    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IHashService hashService;
        private readonly ITokenService tokenService;
        private readonly IMailService mailService;

        private readonly IFileService fileService;

        public UserService(
            IMapper mapper,
            ITokenService tokenService,
            IHashService hashService,
            IMailService mailService,
            IUserRepository userRepository,
            ILoggerRepository loggerRepository,
            IFileService fileService,
            IStoreOperationConfigurationContext configContext) : base(mapper, loggerRepository,
            configContext)
        {
            this.tokenService = tokenService;
            this.hashService = hashService;
            this.mailService = mailService;
            this.userRepository = userRepository;
            this.fileService = fileService;
        }

        public async Task<ApiResponse> ChangePasswordAsync(UpdatePasswordRequest request)
        {
            string hashedLastPassword =
                hashService.CreateHash(request.LastPassword, _configContext.JwtSecret);

            var currentUser = await userRepository.GetAsync(request.UserId, hashedLastPassword);

            if (currentUser == null)
            {
                return new ErrorApiResponse(ResultMessage.NotFoundUser);
            }

            currentUser.Password = hashService.CreateHash(request.NewPassword);

            await userRepository.UpdateAsync(currentUser);

            return new SuccessApiResponse(ResponseStatus.Ok, ResultMessage.SuccessUpdate);
        }

        public async Task<ApiResponse<UserLoginResponse>> LoginAsync(UserLoginRequest request)
        {
            var hashedPassword = hashService.CreateHash(request.Password, _configContext.JwtSecret);

            var user = await userRepository.GetAsync(request.UserName, hashedPassword);


            if (user == null)
            {
                return new ErrorApiResponse<UserLoginResponse>(ResponseStatus.UnAuthorized, null,
                    ResultMessage.InvalidUserNameOrPassword);
            }

            if (!user.UserNameConfirmed.HasValue || !user.UserNameConfirmed.Value)
            {
                return new ErrorApiResponse<UserLoginResponse>(ResponseStatus.UnAuthorized, null,
                    ResultMessage.UserNameIsNotValidated);
            }

            // kullanıcının aktif olduğu mağaza bilgilerini alıyoruz. 
            // belenen bir mağaza bilgisidir.
            var userAppStore = user.RelationStoreUsers.Where(x => x.State == RelationStoreUserState.Active.ToInt())
                .ToArray();
            //
            if (!userAppStore.Any())
            {
                return new ErrorApiResponse<UserLoginResponse>(null, ResultMessage.HasNotStore);
            }

            //todo fake 
            //var tokenData = tokenService.CreateToken(user.UserId, userAppStore?.First().StoreId??Guid.NewGuid());
            var tokenData = tokenService.CreateToken(user.UserId, userAppStore.First().StoreId);

            user.Token = tokenData.Token;
            user.TokenExpireDate = tokenData.ExpiredDate;

            await userRepository.SaveASync();

            var mappedUser = _mapper.Map<AppUser, UserDto>(user);

            var loginResponse = new UserLoginResponse(mappedUser, user.Token, user.TokenExpireDate);

            return new SuccessApiResponse<UserLoginResponse>(ResponseStatus.Ok, loginResponse,
                ResultMessage.UserPasswordChanged);
        }

        public async Task<ApiResponse> RegisterAsync(RegisterUserRequest request)
        {
            var checkFileResult = await fileService.InsertProfileImageAsync(request.ProfileImage);

            if (!checkFileResult.IsSuccess)
            {
                return new ErrorApiResponse(checkFileResult.ErrorMessage);
            }

            request.ProfileImageUrl = checkFileResult.RelativeFilePath;
            request.Password = hashService.CreateHash(request.Password);

            AppUser _user = _mapper.Map<AppUser>(request);

            //todo doğrulama e-postası gönderildiğinde kaldırılıcak
            _user.UserNameConfirmed = true;
            //_user.UserId = Guid.NewGuid();

            await userRepository.AddAsync(_user);
            //todo doğrulama e-postası gönderilecek 

            return new SuccessApiResponse(ResponseStatus.Created, ResultMessage.UserRegistered);
        }

        public async Task<ApiResponse> RemindPasswordAsync(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                return new ApiResponse();
            }

            var currentUser = await userRepository.GetByEmailAsync(email);

            if (currentUser == null)
            {
                return new ErrorApiResponse(ResultMessage.NotFoundUser);
            }

            currentUser.SecurityKey = Guid.NewGuid();
            currentUser.SecurityKeyExpiryDate =
                DateTime.Now.AddHours(_configContext.SecurityKeyExpiryFromHours);

            await userRepository.UpdateAsync(currentUser);

            await SendRemindPasswordMailAsync(currentUser);

            return new SuccessApiResponse(ResponseStatus.Ok, ResultMessage.VerificationEmailSent);
        }

        private async Task SendRemindPasswordMailAsync(AppUser user)
        {
            var to = new List<string> {user.Email};
            string securityKey = user.SecurityKey.ToString();
            string subject = "CheckedList Programı | Parola Sıfırlama İsteği";
            string remindPasswordUrl =
                $"{_configContext.UpdatePasswordWebPageUrl}?securityKey={securityKey}";
            string body =
                $"Merhaba {user.Name} {user.SurName}, <a href='{remindPasswordUrl}' target='_blank'>buradan</a> parolanızı sıfırlayabilirsiniz.";

            await mailService.SendEmailAsync(to, subject, body);
        }

        public async Task<ApiResponse> UpdateAsync(UpdateUserRequest request)
        {
            var currentUser = await userRepository.GetByIdAsync(request.UserId);

            if (request.ProfileImage != null)
            {
                var checkUploadedImageFileResult = await fileService.InsertProfileImageAsync(request.ProfileImage);

                if (!checkUploadedImageFileResult.IsSuccess)
                {
                    return new ErrorApiResponse(checkUploadedImageFileResult.ErrorMessage);
                }

                currentUser.ProfileImageUrl = checkUploadedImageFileResult.RelativeFilePath;
            }

            currentUser.Name = request.Name;
            currentUser.SurName = request.SurName;

            await userRepository.UpdateAsync(currentUser);
            var userDto = _mapper.Map<UserDto>(currentUser);

            return new SuccessApiResponse<UserDto>(ResponseStatus.Ok, userDto, ResultMessage.UserUpdate);
        }

        public async Task<ApiResponse> RemindPasswordCompleteAsync(CompleteRemindPasswordRequest request)
        {
            var currentUser = await userRepository.GetAsync(request.SecurityKey);

            if (currentUser == null)
            {
                return new ErrorApiResponse(ResultMessage.InvalidSecurityKey);
            }

            if (currentUser.SecurityKeyExpiryDate < DateTime.Now)
            {
                return new ErrorApiResponse(ResultMessage.SecurityKeyExpiryDateAlreadyExpired);
            }

            currentUser.SecurityKey = null;
            currentUser.Password = hashService.CreateHash(request.Password);

            await userRepository.UpdateAsync(currentUser);

            return new SuccessApiResponse(ResponseStatus.Ok);
        }

        public async Task<ApiResponse> GetUserInfoAsync(string id)
        {
            var users = await userRepository.GetAllAsync(x => x.Token == id);
            if (users.Count() != 1)
            {
                return new ErrorApiResponse("Kullanıcı token bilgisi kayıtlı değil veya birden çok kişiye atanmış.");
            }

            var info = _mapper.Map<UserInfoResponse>(users.First());
            return new SuccessApiResponse<UserInfoResponse>(ResponseStatus.Ok, info);
        }


        public async Task<ApiResponse> GetProfileImageAsync(string token)
        {
            var users = await userRepository.GetAllAsync(x => x.Token == token);
            if (users.Count() != 1)
            {
                return new ErrorApiResponse("Kullanıcı token bilgisi kayıtlı değil veya birden çok kişiye atanmış.");
            }
            
            var file = await fileService.ReadProfileImageAsync(users.First().ProfileImageUrl);
            if (file.IsSuccess)
            {
                return new SuccessApiResponse<ReadImageResult>(file);
            }
            else
            {
                return new ErrorApiResponse(file.ErrorMessage);
            }
        }
    }
}