using System;
using System.Collections.Generic;
using StoreOperation.WebApi.CustomEntities.Dto;

namespace StoreOperation.WebApi.CustomEntities.Response.CheckListResponse
{
    public class CheckListDayReport
    {
        public string Day { get; set; }
        public string Store { get; set; }
        public IEnumerable<CheckListDayReportList> Summaries { get; set; }
        public IEnumerable<CheckListDayReportGroup> Groups { get; set; }
    }

    public class CheckListDayReportList
    {
        public CheckListDayReportList(Guid checkListId, int rank, int totalTrue, int totalFalse, DateTime timespan)
        {
            CheckListId = checkListId;
            Rank = rank;
            TotalTrue = totalTrue;
            TotalFalse = totalFalse;
            Timespan = timespan.ToString("hh:mm:ss");
        }
        public Guid CheckListId { get; set; }
        public int Rank { get; set; }
        public int TotalTrue { get; set; }
        public int TotalFalse { get; set; }
        public string Timespan { get; set; }
    }
    
    public class CheckListDayReportGroup
    {
        public CheckListDayReportGroup(string @group, Guid groupId, IEnumerable<CheckListAnswersToQuestionDto> questions)
        {
            Group = @group;
            GroupId = groupId;
            Questions = questions;
        }

        public string Group { get; set; }
        public Guid GroupId { get; set; }
        public IEnumerable<CheckListAnswersToQuestionDto> Questions { get; set; }
    }
}