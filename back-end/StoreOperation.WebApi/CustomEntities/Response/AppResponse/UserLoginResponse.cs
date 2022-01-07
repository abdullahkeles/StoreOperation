using System;
using StoreOperation.WebApi.CustomEntities.Dto;

namespace StoreOperation.WebApi.CustomEntities.Response.AppResponse
{
    public class UserLoginResponse
    {
        public UserLoginResponse(UserDto user, string token, DateTime? tokenExpiryDate)
        {
            User = user;
            Token = token;
            TokenExpiryDate = tokenExpiryDate;
        }

        public UserDto User { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpiryDate { get; set; }
    }
}
