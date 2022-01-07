using System;
using System.Collections.Generic;

namespace StoreOperation.WebApi.Data.Entities
{
    public partial class AppUser
    {
        public AppUser()
        {
            RelationStoreUsers = new HashSet<AppUserAppStore>();
            Roles = new HashSet<AppRole>();
        }
        public Guid UserId { get; set; }
        // tckn | eposta | oid
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string OfficePhone { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool? UserNameConfirmed { get; set; }
        public int? UserState { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }
        public string ProfileUrl { get; set; }
        public DateTime? SecurityKeyExpiryDate { get; set; }
        public Guid? SecurityKey { get; set; }
        public virtual ICollection<AppUserAppStore> RelationStoreUsers { get; set; }
        public virtual ICollection<AppRole> Roles { get; set; } 
    }
}