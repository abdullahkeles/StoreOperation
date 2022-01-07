using System;

namespace StoreOperation.WebApi.CustomEntities.Request.App
{
    public class UpdateStore : CreateStore
    {
        public Guid StoreId { get; set; }
    }
}