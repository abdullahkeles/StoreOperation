using System;
using System.Collections.Generic;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.CustomEntities.Dto
{
    public class CheckListDto
    {
        public CheckListDto(CheckList checkList)
        {
            CheckListDayId = checkList.CheckListDayId;
            CheckListId = checkList.CheckListId;
            Rank = checkList.Rank;
            Name = checkList.Certifying.Name;
            Surname = checkList.Certifying.SurName;
            TimeSpan = checkList.TimeSpan.ToString("HH:mm");
            Note = checkList.Note;
        }
        public Guid CheckListId { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TimeSpan { get; set; }
        public Guid CheckListDayId { get; set; }
        public string Note { get; set; }
    }
}