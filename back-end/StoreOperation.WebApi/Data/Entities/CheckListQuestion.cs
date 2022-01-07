using System;

namespace StoreOperation.WebApi.Data.Entities
{
    public partial class CheckListQuestion
    {
        public Guid CheckListQuestionId { get; set; }
        public string Question { get; set; }
        public byte Skor { get; set; }
        public bool State { get; set; }
        public int? Sort { get; set; }
        public Guid CheckListQuestionGroupId { get; set; }
        public CheckListQuestionGroup Group { get; set; }
    }
}
