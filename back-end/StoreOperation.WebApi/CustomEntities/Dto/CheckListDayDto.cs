using System;
using System.Collections.Generic;
using System.Linq;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.CustomEntities.Dto
{
    public class CheckListDayDto
    {
        public CheckListDayDto(CheckListDay day)
        {
            CheckListDayId = day.CheckListDayId;
            Day = day.Day;
            StoreId = day.StoreId;
            Rank = day.Rank;
            CheckLists = day.CheckLists.Select(x => new CheckListDto(x)).OrderByDescending(x => x.Rank).ToArray();
        }
        
        public Guid CheckListDayId { get; set; }
        public DateTime Day { get; set; }
        public Guid StoreId { get; set; }
        public IEnumerable<CheckListDto> CheckLists { get; set; }
        public int Rank { get; set; }
    }
}