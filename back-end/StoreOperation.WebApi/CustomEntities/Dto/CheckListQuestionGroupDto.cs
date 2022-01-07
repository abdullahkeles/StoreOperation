using System;

namespace StoreOperation.WebApi.CustomEntities.Dto
{
    public class CheckListQuestionGroupDto
    {

        public CheckListQuestionGroupDto()
        {
            
        }

        public CheckListQuestionGroupDto(Guid checkListQuestionGroupId, string name, bool state, int? sort,int totalSkor=0)
        {
            CheckListQuestionGroupId = checkListQuestionGroupId;
            Name = name;
            State = state;
            Sort = sort;
            TotalSkor = totalSkor;
        }

        public Guid CheckListQuestionGroupId { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public int TotalSkor { get; set; }
        public int? Sort { get; set; }
    }
}