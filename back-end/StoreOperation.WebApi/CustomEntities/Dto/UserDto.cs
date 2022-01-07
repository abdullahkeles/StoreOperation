using System.Collections.Generic;
using System.Linq;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.CustomEntities.Dto
{
    public class UserDto
    {
        public UserDto()
        {
            ShopeStores = new List<AppStore>();
            Roles = new List<AppRole>();
        }

        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string ProfileUrl { get; set; }

        public bool IsShopeStore => ShopeStores.Any();
        public bool IsRole => Roles.Any();
        public virtual ICollection<AppStore> ShopeStores { get; set; }
        public virtual ICollection<AppRole> Roles { get; set; }
    }
}
