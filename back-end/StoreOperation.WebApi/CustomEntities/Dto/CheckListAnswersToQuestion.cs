using System;
using System.Collections.Generic;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.CustomEntities.Dto
{
    public class CheckListAnswersToQuestionDto
    {
        public CheckListAnswersToQuestionDto(Guid questionId, string question, Guid groupId, IEnumerable<CheckListQuestionAnswerDto> answers)
        {
            QuestionId = questionId;
            Question = question;
            GroupId = groupId;
            Answers = answers;
        }

        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public Guid GroupId { get; set; }
        public IEnumerable<CheckListQuestionAnswerDto> Answers { get; set; } 
    }
}