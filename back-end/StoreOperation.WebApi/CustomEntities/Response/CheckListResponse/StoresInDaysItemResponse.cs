using System.Collections.Generic;
using StoreOperation.WebApi.CustomEntities.Dto;

namespace StoreOperation.WebApi.CustomEntities.Response.CheckListResponse
{
    public class CheckListDaysResponse
    {
        public CheckListDaysResponse()
        {
        }
        public CheckListDaysResponse(AppStoreDto store, IEnumerable<CheckListDayDto> checkListDays)
        {
            Store = store;
            CheckListDays = checkListDays;
        }
        public AppStoreDto Store { get; set; }
        public IEnumerable<CheckListDayDto> CheckListDays { get; set; }
    }
}