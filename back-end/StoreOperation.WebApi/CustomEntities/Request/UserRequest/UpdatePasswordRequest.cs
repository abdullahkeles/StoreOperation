using System;
using System.ComponentModel.DataAnnotations;

namespace StoreOperation.WebApi.CustomEntities.Request.UserRequest
{
    public class UpdatePasswordRequest
    {
        public Guid UserId { get; set; }

        [Required]
        public string LastPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
