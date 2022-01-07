using System;
using System.Collections.Generic;

namespace StoreOperation.WebApi.Data.Entities
{
    public partial class AppStore
    {
        public AppStore()
        {
            RelationShopeStoreUser = new HashSet<AppUserAppStore>();
        }

        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string VergiKimlikNo { get; set; }
        public int IlId { get; set; }
        public int IlceId { get; set; }
        public string Adress { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeFax { get; set; }
        public string Email { get; set; }
        public bool StoreState { get; set; }
        public int CategoryId { get; set; }

        public ICollection<AppUserAppStore> RelationShopeStoreUser { get; set; }
        
    }
}