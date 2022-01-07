using System;

namespace StoreOperation.WebApi.CustomEntities.Request.CheckList
{
    public class QuestionCreateRequest
    {
        public string Question { get; set; }
        public byte Skor { get; set; }
        public bool State { get; set; }
        public int? Sort { get; set; }
        public Guid CheckListQuestionGroupId { get; set; }
    }
}