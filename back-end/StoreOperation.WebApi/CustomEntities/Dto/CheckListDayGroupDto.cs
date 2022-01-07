using System;
using System.Collections.Generic;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.CustomEntities.Dto
{
    public class CheckListDayGroupDto
    {
        public CheckListDayGroupDto(DateTime day, IEnumerable<CheckListDay> checkListDays)
        {
            Day = day;
            CheckListDays = checkListDays;
        }

        public CheckListDayGroupDto()
        {
                
        }
        public DateTime Day { get; set; }
        public IEnumerable<CheckListDay> CheckListDays { get; set; }
    }
}