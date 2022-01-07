using System;

namespace StoreOperation.WebApi.Data.Entities
{
    public partial class CheckListQuestionAnswer
    {
        public Guid CheckListQuestionAnswerId { get; set; }
        public bool Answer { get; set; }
        public byte AnswerState { get; set; }
        public byte Skor { get; set; }
        public Guid CheckListId { get; set; }
        public CheckList CheckList { get; set; }
        public Guid CheckListQuestionId { get; set; }
        public CheckListQuestion CheckListQuestion { get; set; }
    }
}
