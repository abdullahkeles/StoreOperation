using System;
using System.Collections.Generic;

namespace StoreOperation.WebApi.Data.Entities
{
    public partial class CheckListQuestionGroup
    {
        public CheckListQuestionGroup(string name)
        {
            Name = name;
        }
        public CheckListQuestionGroup()
        {
            CheckListQuestions = new HashSet<CheckListQuestion>();
        }
        public Guid CheckListQuestionGroupId { get; set; }
        public ICollection<CheckListQuestion> CheckListQuestions { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public int? Sort { get; set; }
    }
}