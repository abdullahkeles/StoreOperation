﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace StoreOperation.WebApi.CustomEntities.Request.UserRequest
{
    public class RegisterUserRequest
    {
        [Required] public string UserName { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string SurName { get; set; }

        [Required] public string MobilePhone { get; set; }

        public string OfficePhone { get; set; }

        public string ProfileImageUrl { get; set; }

        [Required] public IFormFile ProfileImage { get; set; }
    }
}