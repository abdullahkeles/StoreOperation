using System;
using System.Collections.Generic;

namespace StoreOperation.WebApi.Data.Entities
{
    public partial class AppRole
    {
        public AppRole()
        {
            Users = new HashSet<AppUser>();
        }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<AppUser> Users { get; set; }
    }
}