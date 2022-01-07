using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Helpers.Extensions;

namespace StoreOperation.WebApi.CustomEntities.Response
{
    public class StoresInDaysItemResponse
    {
        public StoresInDaysItemResponse(CheckListDayGroupDto day)
        {
            
            Day = day.Day.ToTurkceMetin();
            DayDate = day.Day.ToString("yyyy/MM/dd");
            BilgiGirisYapılmadı = $"Bilgi Girşi Yapılmadı : {day.CheckListDays.Where(x => x.Rank == 0).Count()}";
            IlkYayin = $"İlk Yayın : {day.CheckListDays.Where(x => x.Rank == 1).Count()}";
            Revizyon = $"Revizyon : {day.CheckListDays.Where(x => x.Rank > 1).Count()}";
        }

        public string Day { get; set; }
        public string DayDate { get; set; }
        public string BilgiGirisYapılmadı { get; set; }
        public string IlkYayin { get; set; }
        public string Revizyon { get; set; }
    }
}