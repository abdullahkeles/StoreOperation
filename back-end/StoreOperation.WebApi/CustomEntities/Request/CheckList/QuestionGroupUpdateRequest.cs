using System;

namespace StoreOperation.WebApi.CustomEntities.Request.CheckList
{
    public class QuestionGroupUpdateRequest
    {
        public Guid CheckListQuestionGroupId { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public int? Sort { get; set; }
    }
}