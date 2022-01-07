using System;
using System.Linq;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.CustomEntities.Response.CheckListResponse
{
    public class StoresInDayResponse
    {
        public StoresInDayResponse(CheckListDay checkListDay)
        {
            StoreId = checkListDay.StoreId;
            StoreName = checkListDay.Store.Name;
            Rank = checkListDay.Rank;
            if (checkListDay.CheckLists.Count>0)
            {
                var checkList = checkListDay.CheckLists.OrderBy(x => x.Rank).First();
                Timespan = checkList.TimeSpan.ToString("hh:ss");
                TotalFalse = checkList.Questions.Count(q => !q.Answer);
                TotalTrue = checkList.Questions.Count(q => q.Answer);
                TotalSkor = checkList.Questions.Where(q => q.Answer).Sum(x => x.Skor);
            }
            
        }
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public int TotalTrue { get; set; }
        public int TotalFalse { get; set; }
        public int TotalSkor { get; set; }
        public string Timespan { get; set; }
        public int Rank { get; set; }
    }
}