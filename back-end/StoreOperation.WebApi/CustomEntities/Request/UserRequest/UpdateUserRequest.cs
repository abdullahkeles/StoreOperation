using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace StoreOperation.WebApi.CustomEntities.Request.UserRequest
{
    public class UpdateUserRequest
    {
        public Guid UserId { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string SurName { get; set; }

        public string MobilePhone { get; set; }

        public string OfficePhone { get; set; }

        public string ProfileImageUrl { get; set; }

        public IFormFile ProfileImage { get; set; }
    }
}